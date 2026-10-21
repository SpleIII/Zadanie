CI/CD пайплайны
---

## Проекты

| # | Проект | Стек | Что публикует | Триггер |
|:-:|---|---|---|---|
| 1 | [`hello-rust`](projects/hello-rust) | Rust + Docker | образ в GHCR | push в `main` |
| 2 | [`hello-go`](projects/hello-go) | Go + Docker | образ в GHCR | push в `main` |
| 3 | [`hello-go-releases`](projects/hello-go-releases) | Go | бинарники (5 платформ) | тег `hello-go-releases-v*` |
| 4 | [`hello-python`](projects/hello-python) | Python + PyInstaller | бинарники (3 ОС) | тег `hello-python-v*` |
| 5 | [`hello-dotnet`](projects/hello-dotnet) | C# / .NET 8 | бинарники (2 платформы) | тег `hello-dotnet-v*` |
| 6 | [`hello-gui`](projects/hello-gui) | Go + Fyne | бинарники (3 платформы) | тег `hello-gui-v*` |
| 7 | [`hex-loader`](projects/hex-loader) | Go + Fyne | бинарники (3 платформы) | тег `hex-loader-v*` |
| 8 | [`arduino-manager`](projects/arduino-manager) | Go + Fyne | бинарники (3 платформы) | тег `arduino-manager-v*` |
| 9 | [`hello-static`](projects/hello-static) | HTML + CSS + JS | сайт на GitHub Pages | push в `main` |
| 10 | [`hello-pages`](projects/hello-pages) | React + Vite | SPA на GitHub Pages | push в `main` |

---

## Структура

```
Zadanie/
├── .github/workflows/       # по файлу на каждый проект
├── projects/                # исходники, разложены по подкаталогам
│   ├── hello-rust/
│   ├── hello-go/
│   ├── hello-go-releases/
│   ├── hello-python/
│   ├── hello-dotnet/
│   ├── hello-gui/
│   ├── hex-loader/
│   ├── arduino-manager/
│   ├── hello-static/
│   └── hello-pages/
├── docs/                    # скриншоты прогона пайплайнов
├── .gitattributes           # единые правила переводов строк
├── .gitignore               # общие исключения
└── README.md
```

---

## Пайплайны

| Файл | Проект | Проверки | Публикация |
|---|---|---|---|
| `rust-ghcr.yml` | hello-rust | fmt, clippy, test, build | образ `ghcr.io/spleiii/zadanie/hello-rust` |
| `go-ghcr.yml` | hello-go | gofmt, vet, test, build | образ `ghcr.io/spleiii/zadanie/hello-go` |
| `go-releases.yml` | hello-go-releases | gofmt, vet, test | 5 бинарников в Releases |
| `python-releases.yml` | hello-python | ruff, pytest | 3 бинарника в Releases |
| `dotnet-releases.yml` | hello-dotnet | build, xUnit | 2 архива в Releases |
| `go-gui-releases.yml` | hello-gui | gofmt, vet, test | 3 бинарника в Releases |
| `hex-loader-releases.yml` | hex-loader | build | 3 бинарника в Releases |
| `arduino-manager-releases.yml` | arduino-manager | build | 3 бинарника в Releases |
| `static-pages.yml` | hello-static | проверка структуры | сайт на Pages |
| `pages-spa.yml` | hello-pages | npm install, vite build | артефакт сборки |

Каждый workflow ограничен фильтром `paths`, поэтому правка одного проекта не
перезапускает чужие пайплайны. Все шаги выполняются из каталога своего
проекта через `defaults.run.working-directory`.

### Теги релизов

У каждого проекта свой префикс тега — `hello-go-releases-v1.0.0`,
`hello-python-v1.0.0` и так далее. Так один репозиторий может релизить
проекты независимо друг от друга, не сталкиваясь за один и тот же релиз.

```bash
git tag hello-go-releases-v1.0.0
git push origin hello-go-releases-v1.0.0
```

Номер версии подставляется в бинарник через `-ldflags "-X main.version=..."`,
префикс проекта при этом отбрасывается.

---

## Живые ссылки

* Сайт на Pages: <https://spleiii.github.io/Zadanie/>
* Образы в GHCR: `ghcr.io/spleiii/zadanie/hello-rust`, `ghcr.io/spleiii/zadanie/hello-go`
* Готовые релизы: [Releases](https://github.com/SpleIII/Zadanie/releases)

Сайт сделан в стиле консоли сборки: тёмная и светлая темы, анимированный
лог прогона пайплайна, копирование команд, счётчик с сохранением в
`localStorage`. Ни сборщика, ни зависимостей — только HTML, CSS и JS.

```bash
docker pull ghcr.io/spleiii/zadanie/hello-rust:latest
docker run --rm ghcr.io/spleiii/zadanie/hello-rust
```

---

## Запуск локально

```bash
# Rust
cd projects/hello-rust && cargo run --release

# Go
cd projects/hello-go && go run .

# Python
cd projects/hello-python && python main.py

# .NET
cd projects/hello-dotnet && dotnet run --project src

# GUI на Fyne (нужны системные библиотеки OpenGL)
cd projects/hello-gui && go run .

# Статический сайт
cd projects/hello-static && python -m http.server 8000 --directory public

# React SPA
cd projects/hello-pages && npm install && npm run dev
```

Подробности по каждому проекту — в его собственном `README.md`.

---

## Что изменено относительно исходных репозиториев

| Было | Стало |
|---|---|
| десять отдельных репозиториев | один монорепозиторий с каталогами `projects/` |
| пайплайн в `.github/workflows/` каждого проекта | единый каталог `.github/workflows/` с отдельным файлом на проект |
| образы `ghcr.io/evgeny65ok/<проект>` | `ghcr.io/spleiii/zadanie/<проект>` |
| тег `v*` для всех | тег с префиксом проекта |
| комментарии в коде | переписаны в едином стиле |
| README в каждом репозитории | README на каждое устройство |

Исходный код проектов при этом не менялся: те же файлы, та же логика, те же
тесты.

---

<p align="center"><i>Сборник учебных CI/CD пайплайнов · 2026</i></p>
