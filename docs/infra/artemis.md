## Artemis

- [Artemis User manual](https://activemq.apache.org/components/artemis/documentation/latest/index.html)
- [Differences From ActiveMQ 5](https://activemq.apache.org/components/artemis/migration-documentation/key-differences.html)
- [Apache ActiveMQ Artemis Migration Guide](https://activemq.apache.org/components/artemis/migration)

## Docker

- [Simple ActiveMQ Artemis cluster](https://github.com/minyk/docker-artemis)
- [Official Images](https://activemq.apache.org/components/artemis/documentation/latest/docker.html)
- [artemis-docker](https://github.com/apache/activemq-artemis/tree/main/artemis-docker)
- [docker-ActiveMQ](https://github.com/xiaoyawl/docker-activemq)
- [reactive-activemq](https://github.com/dnvriend/reactive-activemq/blob/master/docker-compose.yml)
- [Configuration for ActiveMQ Artemis cluster on many Docker containers?](https://stackoverflow.com/questions/69531342/configuration-for-activemq-artemis-cluster-on-many-docker-containers)
- [Apache ActiveMQ using Docker Compose](https://bobcares.com/blog/apache-activemq-using-docker-compose/)

### Basic sample

```
$ docker run --detach --name my-artemis -p 61616:61616 -p 8161:8161 --rm apache/activemq-artemis:latest-alpine

# Once the broker starts you can open the web management console at http://localhost:8161 and log in with the default username & password artemis

# You can also use the shell command to interact with the running broker using the default username & password artemis
# https://activemq.apache.org/components/artemis/documentation/latest/using-cli.html#command-line-interface

$ docker exec -it my-artemis /var/lib/artemis-instance/bin/artemis shell --user artemis --password artemis

$ docker logs -f my-artemis

$ docker stop my-artemis

```



## NMS

- [NMS](https://activemq.apache.org/components/nms/)
- [simple-example](https://activemq.apache.org/components/nms/examples/nms-simple-asynchronous-consumer-example)
- [activemq-nms-api](https://github.com/apache/activemq-nms-api)
- [apache/activemq-nms-openwire](https://github.com/apache/activemq-nms-openwire)

### Examples

- [Exaple Docs](https://activemq.apache.org/components/artemis/documentation/latest/examples.html)
- [Examples](https://github.com/apache/activemq-artemis-examples)

## Havret

- [dotnet-activemq-artemis-client](https://github.com/Havret/dotnet-activemq-artemis-client)
- [getting-started](https://havret.github.io/dotnet-activemq-artemis-client/docs/getting-started/)
- [activemq-artemis-net-core](https://havret.io/activemq-artemis-net-core)

## Understanding Message Brokers

- [ActiveMQ](https://habr.com/ru/articles/471268/)

## Samples
- [active-mq-artemis-and-c-net-core](https://stackoverflow.com/questions/75597529/active-mq-artemis-and-c-net-core)






