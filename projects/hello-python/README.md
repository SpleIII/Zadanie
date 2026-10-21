# hello-python

CLI на Python, который упаковывается в один исполняемый файл через
**PyInstaller** и публикуется в **GitHub Releases** под три операционные
системы. Главная особенность проекта — кросс-компиляция здесь невозможна,
поэтому матрица собирает каждую ОС на своём раннере.

## Что проверяет пайплайн

| Шаг | Инструмент | Что проверяет |
|---|---|---|
| Линт | `ruff check` | качество кода |
| Форматирование | `ruff format --check` | единый стиль |
| Тесты | `pytest -v` | юнит-тесты пакета `hello` |
| Сборка | `PyInstaller --onefile` | готовый бинарник без Python |

Публикация происходит по тегу с префиксом проекта: `hello-python-v1.0.0`.

## Матрица сборки

| ОС | Файл |
|---|---|
| Linux x64 | `hello-python-linux-x64` |
| macOS arm64 | `hello-python-macos-arm64` |
| Windows x64 | `hello-python-windows-x64.exe` |

## Структура

```
hello-python/
├── main.py            # точка входа, печатает версию и приветствие
├── pyproject.toml     # метаданные пакета и настройки pytest
├── requirements.txt   # pytest + pyinstaller
├── hello/
│   ├── __init__.py    # версия пакета
│   └── greeting.py    # greet() и sum_range()
└── tests/
    └── test_greeting.py
```

## Запуск

```bash
# локально
python main.py
python -m pytest -v

# вручную собрать бинарник
pip install -r requirements.txt
python -m PyInstaller --onefile --name hello-python main.py
./dist/hello-python
```

## Пример вывода

```text
hello-python version 0.1.0
Hello from Python! 🐍📦
OS: linux
Arch: x86_64
Hello, GitHub!
Sum 1..10 = 55
```

## Новый релиз

```bash
git tag hello-python-v1.0.0
git push origin hello-python-v1.0.0
```

---

[← к списку проектов](../../README.md)
