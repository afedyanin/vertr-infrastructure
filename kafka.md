# Kafka docs

- [quickstart](https://kafka.apache.org/quickstart)
- [Kafka Docker Image Usage Guide](https://github.com/apache/kafka/blob/trunk/docker/examples/README.md)
- [Kafka Docs](https://kafka.apache.org/documentation/)
- [Kafka Command-Line Interface (CLI) Tools](https://docs.confluent.io/kafka/operations-tools/kafka-tools.html)
- [Обзор UI-инструментов для мониторинга и управления кластерами Apache Kafka](https://habr.com/ru/companies/flant/articles/688190/)
- [Docker Volumes](https://docs.docker.com/storage/volumes/)

## Quick Start

### Start Kafka

```
docker pull apache/kafka:latest

docker run -d -p 9092:9092 apache/kafka:latest


```



### Create topics

```
kafka-topics.bat --create --topic quickstart-events --bootstrap-server localhost:9092

kafka-topics.bat --describe --topic quickstart-events --bootstrap-server localhost:9092
```

### Write to topic

```
kafka-console-producer.bat --topic quickstart-events --bootstrap-server localhost:9092
This is my first event
This is my second event
```

You can stop the producer client with Ctrl-C at any time.


### Read Events

```
kafka-console-consumer.bat --topic quickstart-events --from-beginning --bootstrap-server localhost:9092
This is my first event
This is my second event
```

You can stop the consumer client with Ctrl-C at any time.

### Terminate

Stop the producer and consumer clients with Ctrl-C, if you haven't done so already.
Stop the Kafka broker with Ctrl-C.

## Docker Image Usage Guide

- [Single Node Plain Text](https://github.com/apache/kafka/blob/trunk/docker/examples/docker-compose-files/single-node/plaintext/docker-compose.yml)

## CLI

- [Download Kafka](https://kafka.apache.org/downloads)
- [Kafka Topics CLI Tutorial](https://www.conduktor.io/kafka/kafka-topics-cli-tutorial/)

## Admin UI

- [kafka-ui](https://github.com/provectus/kafka-ui)
- [kafdrop](https://github.com/obsidiandynamics/kafdrop) - use https://github.com/obsidiandynamics/kafdrop/blob/master/docker-compose/kafka-kafdrop/docker-compose.yaml 
- [kafkatool](https://www.kafkatool.com/download.html)


## Code C#

https://docs.confluent.io/kafka-clients/dotnet/current/overview.html
https://docs.confluent.io/platform/current/clients/confluent-kafka-dotnet/_site/api/Confluent.Kafka.html
https://github.com/confluentinc/confluent-kafka-dotnet

- [Building Reliable Kafka Producers and Consumers in .NET](https://thecloudblog.net/post/building-reliable-kafka-producers-and-consumers-in-net/)
- [Event-Driven Architecture with Apache Kafka for .NET Developers Part 1 - Event Producer](https://thecloudblog.net/post/event-driven-architecture-with-apache-kafka-for-net-developers-part-1-event-producer/)



