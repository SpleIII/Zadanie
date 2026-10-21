# hello-gui

Настольное приложение на Go с интерфейсом **Fyne**. Собирается под три
платформы и публикуется в **GitHub Releases**. Отличие от консольных
проектов — нужен GUI-тулкит, а на Windows ещё и C-компилятор.

## Что проверяет пайплайн

| Шаг | Команда | Зачем |
|---|---|---|
| Форматирование | `gofmt -l` | единый стиль кода |
| Линтинг | `go vet ./...` | базовая статическая проверка |
| Тесты | `go test ./... -v` | проверки `Greeting` и `SumRange` |
| Сборка | `go build` | контроль, что окно собирается |
| Релиз | матрица ОС | три бинарника за один прогон |

Публикация происходит по тегу с префиксом проекта: `hello-gui-v1.0.0`.

## Системные зависимости

Fyne требует системных библиотек — на Linux их ставит сам пайплайн:

```bash
sudo apt-get install -y libgl1-mesa-dev libegl1-mesa-dev xorg-dev \
    libwayland-dev libxkbcommon-dev wayland-protocols
```

На Windows компилятор подтягивается через `msys2/setup-msys2`, путь к `gcc`
прописывается в `CC`.

## Матрица сборки

| ОС | Файл | Особенности |
|---|---|---|
| Linux x64 | `hello-gui-linux-x64` | — |
| macOS arm64 | `hello-gui-macos-arm64` | — |
| Windows x64 | `hello-gui-windows-x64.exe` | флаг `-H windowsgui`, без консоли |

## Структура

```
hello-gui/
├── go.mod
├── Dockerfile.test     # образ с GUI-зависимостями для локальной сборки
├── main.go             # окно приложения и кнопки
├── logic.go            # Greeting() и SumRange()
└── logic_test.go       # тесты логики
```

## Запуск

```bash
# локально (нужны GUI-зависимости из списка выше)
go run .
go test ./...

# в подготовленном образе
docker build -f Dockerfile.test -t hello-gui-dev .
```

## Что умеет приложение

* показывает версию, ОС и сумму чисел от 1 до 10;
* по кнопке «Поздороваться» выводит приветствие;
* номер версии приходит из `-ldflags "-X main.version=..."`.

## Новый релиз

```bash
git tag hello-gui-v1.0.0
git push origin hello-gui-v1.0.0
```

---

[← к списку проектов](../../README.md)
