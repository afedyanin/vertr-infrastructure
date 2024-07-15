using Confluent.Kafka;

namespace Vertr.Infrastructure.Kafka.Abstractions;
public interface IProducerWrapper<TKey, TValue>
{
    Task<DeliveryResult<TKey, TValue>> Produce(
        string topic,
        TKey key,
        TValue value,
        DateTime timestamp,
        CancellationToken cancellationToken);
}
