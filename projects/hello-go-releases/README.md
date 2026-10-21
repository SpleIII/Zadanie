# hello-go-releases

Кросс-компиляция Go-программы под пять платформ и публикация готовых
бинарников в **GitHub Releases**. Отличие от `hello-go`: контейнера здесь нет
вовсе — на выходе идут обычные исполняемые файлы.

## Что проверяет пайплайн

| Шаг | Команда | Зачем |
|---|---|---|
| Форматирование | `gofmt -l` | единый стиль кода |
| Линтинг | `go vet ./...` | базовая статическая проверка |
| Тесты | `go test ./... -v` | проверки пакета `greeting` |
| Сборка | `go build` | контроль, что код компилируется |
| Релиз | матрица `GOOS`/`GOARCH` | пять бинарников за один прогон |

Релиз создаётся по тегу с префиксом проекта: `hello-go-releases-v1.0.0`.
Так один репозиторий может релизить несколько проектов независимо.

## Матрица сборки

| ОС | Архитектура | Имя файла |
|---|---|---|
| Linux | amd64 | `hello-go-linux-amd64` |
| Linux | arm64 | `hello-go-linux-arm64` |
| macOS | amd64 | `hello-go-darwin-amd64` |
| macOS | arm64 | `hello-go-darwin-arm64` |
| Windows | amd64 | `hello-go-windows-amd64.exe` |

Номер версии подставляется на этапе сборки:

```bash
go build -ldflags="-s -w -X main.version=v1.0.0" -o hello-go-linux-amd64 .
```

## Запуск

```bash
# локально
go run .
go test ./...

# скачанный бинарник
chmod +x hello-go-linux-amd64
./hello-go-linux-amd64
```

## Пример вывода

```text
hello-go version v1.0.0
Hello from Go! 🐹
OS: linux
Arch: amd64
Hello, GitHub!
Sum 1..10 = 55
```

## Новый релиз

```bash
git tag hello-go-releases-v1.0.0
git push origin hello-go-releases-v1.0.0
```

---

[← к списку проектов](../../README.md)
