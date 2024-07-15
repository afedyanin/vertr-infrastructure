using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Vertr.Infrastructure.Kafka.Tests;
public abstract class KafkaTestBase
{
    protected ServiceProvider ServiceProvider { get; private set; }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        var services = new ServiceCollection();

        var kafkaSettings = new KafkaSettings();

        kafkaSettings.ConsumerSettings.GroupId = "TestGroupId";

        services.AddKafkaSettings(settings =>
        {
            settings.ConsumerSettings = kafkaSettings.ConsumerSettings;
            settings.ProducerSettings = kafkaSettings.ProducerSettings;
            settings.Topics = kafkaSettings.Topics;
        });

        services.AddKafkaProducer<string?, string>();
        services.AddKafkaConsumer<Ignore, string>();

        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Debug);
        });

        ServiceProvider = services.BuildServiceProvider();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        ServiceProvider.Dispose();
    }
}
