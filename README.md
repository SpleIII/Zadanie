# Zadanie — учебные CI/CD пайплайны в одном репозитории

Монорепозиторий с учебными пайплайнами сборки и публикации: десять небольших
проектов на разных стеках, у каждого — свой GitHub Actions сценарий
(контейнер в реестр, бинарники в Releases, статический сайт на Pages).

Проекты разложены по каталогам `projects/`, пайплайны собраны в
`.github/workflows/` и срабатывают только на изменениях «своего» проекта.

---

## Содержимое

| Проект | Стек | Что публикует | Триггер |
|---|---|---|---|
| [`hello-rust`](projects/hello-rust) | Rust + Docker | образ в GHCR | push в `main` |
| [`hello-go`](projects/hello-go) | Go + Docker | образ в GHCR | push в `main` |
| [`hello-go-releases`](projects/hello-go-releases) | Go | бинарники (5 платформ) | тег `hello-go-releases-v*` |
| [`PythonCLIRep`](projects/PythonCLIRep) | Python + PyInstaller | бинарники (3 ОС) | тег `PythonCLIRep-v*` |
| [`hello-dotnet`](projects/hello-dotnet) | C# / .NET 8 | бинарники (2 платформы) | тег `hello-dotnet-v*` |
| [`hello-gui`](projects/hello-gui) | Go + Fyne | бинарники (3 платформы) | тег `hello-gui-v*` |
| [`hex-loader`](projects/hex-loader) | Go + Fyne | бинарники (3 платформы) | тег `hex-loader-v*` |
| [`arduino-manager`](projects/arduino-manager) | Go + Fyne | бинарники (3 платформы) | тег `arduino-manager-v*` |
| [`hello-static`](projects/hello-static) | HTML + CSS + JS | сайт на GitHub Pages | push в `main` |
| [`hello-pages`](projects/hello-pages) | React + Vite | SPA на GitHub Pages | push в `main` |

---

## Структура

```
Zadanie/
├── .github/workflows/      # пайплайны всех проектов
├── projects/               # исходники проектов
│   ├── hello-rust/
│   ├── hello-go/
│   └── ...
├── .gitattributes          # единые правила переводов строк
├── .gitignore              # общие исключения
└── README.md
```

---

## Пайплайны

Каждый проект получил собственный файл в `.github/workflows/`:

| Файл | Проект |
|---|---|
| `rust-ghcr.yml` | hello-rust |
| `go-ghcr.yml` | hello-go |
| `go-releases.yml` | hello-go-releases |
| `python-releases.yml` | PythonCLIRep |
| `dotnet-releases.yml` | hello-dotnet |
| `go-gui-releases.yml` | hello-gui |
| `hex-loader-releases.yml` | hex-loader |
| `arduino-manager-releases.yml` | arduino-manager |
| `static-pages.yml` | hello-static |
| `pages-spa.yml` | hello-pages |

Общие черты: проверка форматирования, линтинг, тесты, сборка, публикация
артефакта. Каждый workflow ограничен фильтром `paths`, поэтому правка одного
проекта не перезапускает чужие пайплайны.

---

## Запуск локально

```bash
# Rust
cd projects/hello-rust && cargo run --release

# Go
cd projects/hello-go && go run .

# Python
cd projects/PythonCLIRep && python main.py

# .NET
cd projects/hello-dotnet && dotnet run --project src

# Статический сайт
cd projects/hello-static && python -m http.server 8000 --directory public
```

Подробные инструкции по каждому проекту — в его собственном `README.md`.

---

<p align="center"><i>Сборник учебных CI/CD пайплайнов · 2026</i></p>
