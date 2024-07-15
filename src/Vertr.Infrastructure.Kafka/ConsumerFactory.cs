using System.Diagnostics;
using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Vertr.Infrastructure.Kafka.Abstractions;

namespace Vertr.Infrastructure.Kafka;
internal sealed class ConsumerFactory : IConsumerFactory
{
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ConsumerConfig ConsumerConfig { get; private set; }

    public ConsumerFactory(IOptions<KafkaSettings> kafkaOptions)
    {
        ConsumerConfig = kafkaOptions.Value.ConsumerSettings;
        _jsonSerializerOptions = kafkaOptions.Value.JsonSerializerOptions ?? new JsonSerializerOptions();

        Debug.Assert(!string.IsNullOrWhiteSpace(ConsumerConfig.GroupId), "Consumer GroupId must be specified.");
    }

    public IConsumer<TKey, TValue> CreateConsumer<TKey, TValue>()
    {
        var consumerBuilder = new ConsumerBuilder<TKey, TValue>(ConsumerConfig);

        var keySerializer = new DefaultJsonSerializer<TKey>(_jsonSerializerOptions);
        var valueSerializer = new DefaultJsonSerializer<TValue>(_jsonSerializerOptions);

        consumerBuilder
            .SetKeyDeserializer(keySerializer)
            .SetValueDeserializer(valueSerializer);

        var consumer = consumerBuilder.Build();

        return consumer;
    }
}
