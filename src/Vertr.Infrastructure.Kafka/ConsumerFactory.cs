using System.Diagnostics;
using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Vertr.Infrastructure.Kafka.Abstractions;

namespace Vertr.Infrastructure.Kafka;
internal sealed class ConsumerFactory : IConsumerFactory
{
    public ConsumerConfig ConsumerConfig { get; private set; }

    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ConsumerFactory(
        IOptions<KafkaSettings> kafkaOptions,
        JsonSerializerOptions? jsonSerializerOptions = null)
    {
        ConsumerConfig = kafkaOptions.Value.ConsumerSettings;
        Debug.Assert(!string.IsNullOrWhiteSpace(ConsumerConfig.GroupId), "ConsumerGroupId must be specified.");

        _jsonSerializerOptions = jsonSerializerOptions ?? new JsonSerializerOptions();
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
