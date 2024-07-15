using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Vertr.Infrastructure.Kafka.Abstractions;

namespace Vertr.Infrastructure.Kafka.Tests;

[TestFixture(Category = "System", Explicit = true)]
public class ConsumerWrapperTests : KafkaTestBase
{
    [Test]
    public void CanCreateConsumerFactory()
    {
        var consumerFactory = ServiceProvider.GetRequiredService<IConsumerFactory>();
        Assert.That(consumerFactory, Is.Not.Null);
    }

    [Test]
    public void CanCreateConsumerWrapper()
    {
        var consumer = ServiceProvider.GetRequiredService<IConsumerWrapper<Ignore, string>>();
        Assert.That(consumer, Is.Not.Null);
    }

    [Test]
    public async Task CanStartConsumerWrapper()
    {
        var consumer = ServiceProvider.GetRequiredService<IConsumerWrapper<Ignore, string>>();
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
