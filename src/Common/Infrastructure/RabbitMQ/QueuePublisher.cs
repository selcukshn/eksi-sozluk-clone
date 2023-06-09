using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Common.Infrastructure.RabbitMQ
{
    public class QueuePublisher : BaseQueue
    {
        public string Exchange { get; set; }
        public string ExchangeType { get; set; }
        public string RoutingKey { get; set; }

        public QueuePublisher(string exchange, string queue, string routingKey, string exchangeType = "direct") : base(queue)
        {
            Exchange = exchange;
            RoutingKey = routingKey;
            ExchangeType = exchangeType;
        }
        public QueuePublisher AutoDeclare()
        {
            return ExchangeDeclare().QueueDeclare().BindQueue();
        }
        public void Publish(object body)
        {
            var message = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(body));
            Channel.BasicPublish(this.Exchange, base.Queue, null, message);
        }

        public QueuePublisher ExchangeDeclare()
        {
            Channel.ExchangeDeclare(this.Exchange, this.ExchangeType);
            return this;
        }
        public QueuePublisher QueueDeclare(bool durable = false, bool exclusive = false, bool autoDelete = false)
        {
            Channel.QueueDeclare(base.Queue, durable, exclusive, autoDelete);
            return this;
        }
        public QueuePublisher BindQueue()
        {
            Channel.QueueBind(base.Queue, this.Exchange, this.RoutingKey);
            return this;
        }
    }
}