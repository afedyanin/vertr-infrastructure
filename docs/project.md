# 2024-09-06

#### На стороне инфры

- реализовать клиента для Редиса
- реализовать базовый слой работы с OpenTelemetry (нугет пакет для сервисного слоя - хостов)
- добавить в слой инфраструктуры прометеус и графану (docker compose)
- реализовать сбор и публикацию системных метрик от инфраструктуры (TProxy, Kafka, Redis, PgSQL)


# 2024-08-07

## Слой инфраструктуры

- Базовая библиотека для работы с Redis - клиент для чтения и публикации данных
- Типовой шаблон EF Core проекта для NpgSql (миграции, базовые ентити, коллекции, базовый репозиторий, квери, пагинация, сортинг, идентификаторы, реляции, транзакции и т.п.)

## Слой сервисов

- Реализовать новый сервис - MarketData
- Реализовать базовый функционал слоя сервисов (см. бэклоги по сервисам)
- Обеспечить старт в докере конфигурации сервисов (композ)
- Мониторинг работы типовой стратегии (текущее выполнение)
- Репорты по портфелю по результатам работы стратегии

## Слой приложений

### Базовый UI для ручной торговли

- Создание портфеля
- Дашборд по маркет дате, скринер
- Тоговля - ручной постинг ордеров, мониторинг
- Репорт по портфелю

### Типовые стратегии

- DMA
- Сигналы на индикаторах

### Стратегии на ML моделях

- ARIMA







