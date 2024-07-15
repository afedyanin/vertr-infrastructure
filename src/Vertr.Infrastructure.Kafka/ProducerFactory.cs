using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Vertr.Infrastructure.Kafka.Abstractions;

namespace Vertr.Infrastructure.Kafka;
internal sealed class ProducerFactory : IProducerFactory
{
    public ProducerConfig ProducerConfig { get; private set; }

    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ProducerFactory(
        IOptions<KafkaSettings> kafkaOptions,
        JsonSerializerOptions? jsonSerializerOptions = null)
    {
        ProducerConfig = kafkaOptions.Value.ProducerSettings;
        _jsonSerializerOptions = jsonSerializerOptions ?? new JsonSerializerOptions();
    }

    public IProducer<TKey, TValue> CreateProducer<TKey, TValue>()
    {
        var producerBuilder = new ProducerBuilder<TKey, TValue>(ProducerConfig);

        var keySerializer = new DefaultJsonSerializer<TKey>(_jsonSerializerOptions);
        var valueSerializer = new DefaultJsonSerializer<TValue>(_jsonSerializerOptions);

        producerBuilder
            .SetKeySerializer(keySerializer)
            .SetValueSerializer(valueSerializer);

        var producer = producerBuilder.Build();
        return producer;
    }
}
