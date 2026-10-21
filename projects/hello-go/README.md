# hello-go

Консольная программа на Go, которая собирается в Docker-образ и уезжает в
**GitHub Container Registry**. Отличается от `hello-rust` тем, что образ
минимальный: `alpine` вместо `debian`, а бинарник статический (`CGO_ENABLED=0`).

## Что проверяет пайплайн

| Шаг | Команда | Зачем |
|---|---|---|
| Форматирование | `gofmt -l` | единый стиль кода |
| Линтинг | `go vet ./...` | базовая статическая проверка |
| Тесты | `go test ./... -v` | проверки пакета `greeting` |
| Сборка | `CGO_ENABLED=0 go build` | статический бинарник без libc |
| Контейнер | `docker/build-push-action` | сборка образа и push в GHCR |

Публикация образа происходит только при push в ветку `main`.

## Структура

```
hello-go/
├── go.mod
├── Dockerfile          # две ступени: golang:alpine → alpine
├── main.go             # точка входа
└── greeting/
    ├── greeting.go       # Greet() и SumRange()
    └── greeting_test.go  # тесты пакета
```

## Запуск

```bash
# локально
go run .
go test ./...

# в контейнере
docker build -t hello-go .
docker run --rm hello-go
```

## Образ в GHCR

```bash
docker pull ghcr.io/spleiii/zadanie/hello-go:latest
docker run --rm ghcr.io/spleiii/zadanie/hello-go
```

## Пример вывода

```text
Hello from Go in Docker! 🐹🐳
OS: linux
Arch: amd64
Hello, Docker!
Sum 1..10 = 55
```

---

[← к списку проектов](../../README.md)
