using System.Text.Json;

namespace SellGold.Payments.Infrastructure.Messaging
{
    public class KafkaEventPublisher
    {

        protected KafkaEventPublisher() { }
        public static Task PublishAsync(string topic, object @event)
        {           

            return Task.CompletedTask;
        }
    }
}
