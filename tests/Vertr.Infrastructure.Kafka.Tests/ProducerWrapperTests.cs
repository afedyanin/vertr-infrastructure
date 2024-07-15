using Microsoft.Extensions.DependencyInjection;
using Vertr.Infrastructure.Kafka.Abstractions;

namespace Vertr.Infrastructure.Kafka.Tests;

[TestFixture(Category = "System", Explicit = true)]
public class ProducerWrapperTests : KafkaTestBase
{
    [Test]
    public void CanCreateProducerFactory()
    {
        var factory = ServiceProvider.GetRequiredService<IProducerFactory>();
        Assert.That(factory, Is.Not.Null);
    }

    [Test]
    public void CanCreateProducer()
    {
        var producer = ServiceProvider.GetRequiredService<IProducerWrapper<string?, string>>();
        Assert.That(producer, Is.Not.Null);
    }

    [Test]
    public async Task CanProduceMessage()
    {
        var producer = ServiceProvider.GetRequiredService<IProducerWrapper<string?, string>>();
        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(20));

        var t = Task.Run(async () =>
        {
            await producer.Produce("topic1", "key", "Hello!", DateTime.UtcNow, cts.Token);
        });

        await t;
        Assert.Pass();
    }

}
