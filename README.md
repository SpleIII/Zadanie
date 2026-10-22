# CI/CD пайплайны — индекс заданий

Здесь лежит только индекс. Каждое учебное задание — **отдельный
репозиторий** со своим пайплайном, своим стеком и своей публикацией.
Код между ними не переиспользуется: одно задание не должно зависеть от
другого.

---

## Задания

| # | Задание | Стек | Что публикует | Релиз |
|:-:|---|---|---|---|
| 1 | [hello-rust](https://github.com/SpleIII/hello-rust) | Rust + Docker | образ в GHCR | [v1.0.0](https://github.com/SpleIII/hello-rust/releases/tag/v1.0.0) |
| 2 | [hello-go](https://github.com/SpleIII/hello-go) | Go + Docker | образ в GHCR | [v1.0.0](https://github.com/SpleIII/hello-go/releases/tag/v1.0.0) |
| 3 | [hello-go-releases](https://github.com/SpleIII/hello-go-releases) | Go | бинарники (5 платформ) | [v1.0.0](https://github.com/SpleIII/hello-go-releases/releases/tag/v1.0.0) |
| 4 | [hello-python](https://github.com/SpleIII/hello-python) | Python + PyInstaller | бинарники (3 ОС) | [v1.0.0](https://github.com/SpleIII/hello-python/releases/tag/v1.0.0) |
| 5 | [hello-dotnet](https://github.com/SpleIII/hello-dotnet) | C# / .NET 8 | бинарники (2 платформы) | [v1.0.0](https://github.com/SpleIII/hello-dotnet/releases/tag/v1.0.0) |
| 6 | [hello-gui](https://github.com/SpleIII/hello-gui) | Go + Fyne | бинарники (3 платформы) | [v1.0.0](https://github.com/SpleIII/hello-gui/releases/tag/v1.0.0) |
| 7 | [hex-loader](https://github.com/SpleIII/hex-loader) | Go + Fyne | бинарники (3 платформы) | [v1.0.0](https://github.com/SpleIII/hex-loader/releases/tag/v1.0.0) |
| 8 | [arduino-manager](https://github.com/SpleIII/arduino-manager) | Go + Fyne | бинарники (3 платформы) | [v1.0.0](https://github.com/SpleIII/arduino-manager/releases/tag/v1.0.0) |
| 9 | [hello-static](https://github.com/SpleIII/hello-static) | HTML + CSS + JS | сайт на GitHub Pages | [v1.0.0](https://github.com/SpleIII/hello-static/releases/tag/v1.0.0) |
| 10 | [hello-pages](https://github.com/SpleIII/hello-pages) | React + Vite | SPA на GitHub Pages | [v1.0.0](https://github.com/SpleIII/hello-pages/releases/tag/v1.0.0) |

### Живые ссылки

| Что | Адрес |
|---|---|
| Статический сайт | <https://spleiii.github.io/hello-static/> |
| React SPA | <https://spleiii.github.io/hello-pages/> |
| Образы в GHCR | `ghcr.io/spleiii/hello-rust`, `ghcr.io/spleiii/hello-go` |
| Релизы | [hello-go-releases](https://github.com/SpleIII/hello-go-releases/releases) · [hello-python](https://github.com/SpleIII/hello-python/releases) · [hello-dotnet](https://github.com/SpleIII/hello-dotnet/releases) · [hello-gui](https://github.com/SpleIII/hello-gui/releases) · [hex-loader](https://github.com/SpleIII/hex-loader/releases) · [arduino-manager](https://github.com/SpleIII/arduino-manager/releases) |

---

## Как это устроено

```mermaid
flowchart TB
  subgraph containers["Контейнеры → GHCR"]
    direction LR
    rust["hello-rust<br/>Rust + Docker"]
    go["hello-go<br/>Go + Docker"]
  end

  subgraph releases["Бинарники → Releases"]
    direction LR
    gorel["hello-go-releases<br/>5 платформ"]
    py["hello-python<br/>3 ОС"]
    dotnet["hello-dotnet<br/>2 платформы"]
    gui["hello-gui<br/>3 платформы"]
    hex["hex-loader<br/>3 платформы"]
    manager["arduino-manager<br/>3 платформы"]
  end

  subgraph pages["Сайты → GitHub Pages"]
    direction LR
    static["hello-static<br/>HTML + CSS + JS"]
    spa["hello-pages<br/>React + Vite"]
  end
```

---

## Общее у всех заданий

Схема пайплайна одна и та же, различаются только инструменты:

```
проверки → сборка → публикация
```

| Этап | Чем занимается |
|---|---|
| Проверки | форматирование, линтинг, тесты — `gofmt`/`cargo fmt`/`ruff`/`clippy`/`dotnet test` |
| Сборка | компиляция под нужные платформы, матрица `GOOS`/`GOARCH`, `PyInstaller`, `vite build`, Docker build |
| Публикация | образ в GHCR, бинарники в GitHub Releases, сайт на GitHub Pages |

Общие принципы, которые повторяются в каждом задании:

* **Гейтинг.** Job публикации объявлен как `needs: test` — релиз собирается
  только после успешных проверок.
* **Теги.** Релиз создаётся по тегу `v*`; версия вшивается в бинарник через
  `-ldflags "-X main.version=..."`.
* **Healthcheck.** Контейнеры с базой данных проверяют готовность
  (`pg_isready`, `wget --spider`), а не просто «запустились».
* **Кэш.** Сборщики кэшируются между прогонами — `actions/cache` для Cargo,
  встроенный кэш `setup-go` и `setup-node`.

---

## Проверка индекса

В этом репозитории живёт один workflow — `check-tasks.yml`. Он ходит по API
GitHub и убеждается, что все десять репозиториев на месте, не архивированы и
не пусты. Если ссылка из индекса развалится, сборка упадёт.

---

## Лицензия

Учебный проект. Образы, исходный код приложений и торговые марки
принадлежат их правообладателям.
