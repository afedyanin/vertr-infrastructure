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