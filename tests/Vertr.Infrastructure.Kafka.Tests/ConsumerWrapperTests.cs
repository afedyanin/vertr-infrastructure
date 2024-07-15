using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vertr.Infrastructure.Kafka.Abstractions;

namespace Vertr.Infrastructure.Kafka.Tests;

[TestFixture(Category = "System", Explicit = true)]
public class ConsumerWrapperTests
{
    private ServiceProvider _serviceProvider;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        var services = new ServiceCollection();

        var kafkaSettings = new KafkaSettings();
        kafkaSettings.ConsumerSettings.GroupId = "TestGroupId";

        services.AddConsumerWrapper<Ignore, string>(settings =>
        {
            settings.ConsumerSettings = kafkaSettings.ConsumerSettings;
        });

        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Debug);
        });

        _serviceProvider = services.BuildServiceProvider();

    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _serviceProvider.Dispose();
    }

    [Test]
    public void CanCreateConsumerFactory()
    {
        var consumerFactory = _serviceProvider.GetRequiredService<IConsumerFactory>();
        Assert.That(consumerFactory, Is.Not.Null);
    }

    [Test]
    public void CanCreateConsumerWrapper()
    {
        var consumer = _serviceProvider.GetRequiredService<IConsumerWrapper<Ignore, string>>();
        Assert.That(consumer, Is.Not.Null);
    }

    [Test]
    public async Task CanStartConsumerWrapper()
    {
        var consumer = _serviceProvider.GetRequiredService<IConsumerWrapper<Ignore, string>>();
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));

        var t = Task.Run(async () =>
        {
            await consumer.Consume(["topic1"], Handle, cts.Token);
        });

        await t;
        Assert.Pass();
    }

    private Task Handle(ConsumeResult<Ignore, string> result, CancellationToken cancellationToken)
    {
        Console.WriteLine("Inside handler");
        return Task.CompletedTask;
    }
}
