# hello-dotnet

Консольное приложение на C#/.NET 8, которое публикуется в
**GitHub Releases** в виде архивов под две платформы. В проекте есть
настоящее решение (`.sln`) с отдельным тестовым проектом на xUnit —
хороший пример того, как в одном репозитории живут код и его проверки.

## Что проверяет пайплайн

| Шаг | Команда | Зачем |
|---|---|---|
| Восстановление | `dotnet restore` | скачать зависимости |
| Сборка | `dotnet build -c Release` | собрать решение целиком |
| Тесты | `dotnet test` | xUnit-тесты класса `Greeting` |
| Публикация | `dotnet publish` | самодостаточная папка с бинарником |
| Релиз | `tar` / `Compress-Archive` | два архива на выходе |

Версия берётся из свойства `Version` в `.csproj` и подставляется в вывод
программы через `Assembly.GetName().Version`.

## Артефакты релиза

| Платформа | Файл |
|---|---|
| Linux x64 | `hello-dotnet-linux-x64.tar.gz` |
| Windows x64 | `hello-dotnet-windows-x64.zip` |

## Структура

```
hello-dotnet/
├── global.json            # фиксация версии SDK (8.0.100)
├── hello-dotnet.sln       # решение: приложение + тесты
├── src/
│   ├── HelloDotnet.csproj
│   ├── Program.cs         # точка входа
│   └── Greeting.cs        # Greet() и SumRange()
└── tests/
    ├── HelloDotnet.Tests.csproj
    └── GreetingTests.cs   # три теста на xUnit
```

## Запуск

```bash
# локально
dotnet restore
dotnet run --project src
dotnet test

# опубликованный бинарник
dotnet publish src/HelloDotnet.csproj -c Release -o publish
./publish/hello-dotnet
```

## Пример вывода

```text
hello-dotnet version 1.0.0
Hello from C#/.NET! 🎯🐳
OS: Linux 6.5.0
Arch: X64
Hello, GitHub!
Sum 1..10 = 55
```

## Новый релиз

```bash
git tag hello-dotnet-v1.0.0
git push origin hello-dotnet-v1.0.0
```

---

[← к списку проектов](../../README.md)
