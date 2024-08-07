# TProxy

## Назначение 

Взаимодействие с [T-Invest API](https://russianinvestments.github.io/investAPI/)

## Функционал

### Rest API

- - Orders
- Instruments
- Market Data (подписка, отписка) 

### Kafka Topics (Producer)

- order-trades
- market-trades
- candles
- order-books
- last-prices
- trading-statuses

## Особенности реализации

Использует единый T-счет для всех операций. Счет (живой или песочный) задается в параметрах конфига.


## Backlog

### 2024-08-07

- реализовать подписку/отписку на маркет дату через REST API
- реализовать взаимодействие Market Data сервиса с TProxy через Кафку
- проверить работу связки Orders <-> TProxy на кейсах постинга ордеров: пост ордера, получение ответа, получение трейдов - закрытие ордера, канцел ордера
- лимитные ордера?
- синк ордеров из TProxy с Orders



