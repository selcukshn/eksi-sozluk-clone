using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Common.Infrastructure.RabbitMQ
{
    public class QueuePublisher : BaseQueue
    {
        public QueuePublisher(string exchange, string queue, string routingKey, string exchangeType = "direct") :
        base(exchange, queue, routingKey, exchangeType)
        {
            base.AutoDeclare();
        }
        public void Publish(object body)
        {
            var message = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(body));
            Channel.BasicPublish(this.Exchange, base.Queue, null, message);
        }
    }
}