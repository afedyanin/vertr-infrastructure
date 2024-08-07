# Redis

- [How to Use the Redis Docker Official Image](https://www.docker.com/blog/how-to-use-the-redis-docker-official-image/)
- [How and Why To Run Redis in Docker](https://kinsta.com/blog/redis-docker/)
- [DockerHub](https://hub.docker.com/_/redis)
- [Using Redis with docker](https://geshan.com.np/blog/2022/01/redis-docker/)


```
docker run --name some-redis -d redis redis-server --save 60 1 --loglevel warning

```

This one will save a snapshot of the DB every 60 seconds if at least 1 write operation was performed (it will also lead to more logs, so the loglevel option may be desirable). 
If persistence is enabled, data is stored in the VOLUME /data, which can be used with --volumes-from some-volume-container or -v /docker/host/dir:/data

- [insight](https://redis.io/insight/)
- [docker](https://hub.docker.com/r/redis/redisinsight)
- [running-redisinsight-using-docker-compose](https://collabnix.com/running-redisinsight-using-docker-compose/)

```
docker run -d --name redisinsight -p 5540:5540 redis/redisinsight:latest
docker run -d --name redisinsight -p 5540:5540 redis/redisinsight:latest -v redisinsight:/data

```

## .NET

- [C#/.NET guide](https://redis.io/docs/latest/develop/connect/clients/dotnet/)
- [NRedisStack](https://github.com/redis/NRedisStack)
- [StackExchange.Redis](https://stackexchange.github.io/StackExchange.Redis/)
- [Redis OM .NET](https://github.com/redis/redis-om-dotnet)

- [Redis for .NET Developer – Connecting with C#](https://taswar.zeytinsoft.com/redis-for-net-developer-connecting-with-c/)
- [Redis for .NET Developers – Redis Pub Sub](https://taswar.zeytinsoft.com/redis-pub-sub/)
- [redis_csharp_netframework](https://github.com/ruzerix/redis_csharp_netframework/tree/main)

## Timeseries

- [](https://redis.io/blog/redistimeseries-ga-making-4th-dimension-truly-immersive/)
- [redislabs/redistimeseries](https://hub.docker.com/r/redislabs/redistimeseries)
- [](https://github.com/RedisTimeSeries)
- [](https://medium.com/@volkovlabs/forecasting-stocks-and-crypto-prices-using-redis-prophet-and-grafana-b1630638d469)

## Prophet

- https://facebook.github.io/prophet/docs/quick_start.html#python-api
- https://github.com/facebook/prophet
- https://medium.com/@cuongduong_35162/facebook-prophet-in-2023-and-beyond-c5086151c138
- https://neuralprophet.com/
- https://github.com/ourownstory/neural_prophet
- 
