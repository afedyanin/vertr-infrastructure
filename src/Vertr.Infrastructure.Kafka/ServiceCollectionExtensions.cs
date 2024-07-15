using Microsoft.Extensions.DependencyInjection;
using Vertr.Infrastructure.Kafka.Abstractions;

namespace Vertr.Infrastructure.Kafka;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConsumerWrapper<TKey, TValue>(
        this IServiceCollection serviceCollection,
        Action<KafkaSettings> configure)
    {
        serviceCollection.AddOptions<KafkaSettings>().Configure(configure);
        serviceCollection.AddSingleton<IConsumerFactory, ConsumerFactory>();

        serviceCollection
            .AddTransient<IConsumerWrapper<TKey, TValue>, ConsumerWrapper<TKey, TValue>>();

        return serviceCollection;
    }
}
