using StackExchange.Redis;

namespace Vertr.Infrastructure.RedisDemo;

// https://taswar.zeytinsoft.com/redis-for-net-developer-connecting-with-c/
public class RedisStore
{
    private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

    static RedisStore()
    {
        var configurationOptions = new ConfigurationOptions
        {
            EndPoints = { "localhost" }
        };

        LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
    }

    public static ConnectionMultiplexer Connection => LazyConnection.Value;

    public static IDatabase RedisCache => Connection.GetDatabase();
}
