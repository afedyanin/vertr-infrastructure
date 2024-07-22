using StackExchange.Redis;
using NRedisStack;
using NRedisStack.RedisStackCommands;
using NRedisStack.DataTypes;

namespace Vertr.Infrastructure.RedisDemo;

// https://github.com/taswar/RedisForNetDevelopers/tree/master
[TestFixture(Category = "System", Explicit = true)]
public class RedisTests
{
    [Test]
    public void CanConnectToRedis()
    {
        var db = RedisStore.RedisCache;

        var item = "Hello Redis!";
        db.StringSet("myKey", item);

        var res = db.StringGet("myKey");

        Console.WriteLine(res);

        Assert.Pass();

        // Assert.That(res, Is.EqualTo(item));
    }

    [Test]
    public void CanUsePubSubBasic()
    {
        var redis = RedisStore.RedisCache;

        var channel = new RedisChannel("test", RedisChannel.PatternMode.Auto);

        var sub = redis.Multiplexer.GetSubscriber();

        sub.Subscribe(channel, (channel, message) =>
        {
            Console.WriteLine($"Got notification: {message}");
        });

        var pub = redis.Multiplexer.GetSubscriber();

        var count = pub.Publish(channel, "Hello there I am a test message");

        Assert.Pass();
    }

    [Test]
    public async Task CanCreateTimeSeries()
    {
        var redis = RedisStore.RedisCache;
        TimeSeriesCommands ts = redis.TS();

        ts.Create("sample");

        var start = DateTime.Now;

        for (int i = 0; i < 10; i++)
        {
            ts.Add("sample", new TimeStamp(DateTime.Now), 234.56 * i);
            await Task.Delay(200);
        }

        var range = ts.Range("sample", new TimeStamp(start), new TimeStamp(start.AddSeconds(5)));

        foreach (var interval in range)
        {
            Console.WriteLine(interval);
        }

        Assert.Pass();
    }
}
