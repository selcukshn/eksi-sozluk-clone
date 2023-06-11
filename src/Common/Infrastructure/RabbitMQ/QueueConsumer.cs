using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Common.Infrastructure.RabbitMQ
{
    public class QueueConsumer : BaseQueue
    {
        public EventingBasicConsumer Consuming { get; set; }
        public QueueConsumer(string queue) : base(queue)
        {
            Consuming = new EventingBasicConsumer(base.Channel);
            base.AutoDeclare(e => e.QueueDeclare());
        }

        public QueueConsumer Received<TModel>(Action<TModel> @event)
        {
            Consuming.Received += (ch, ea) =>
            {
                var body = Encoding.UTF8.GetString(ea.Body.ToArray());
                var model = JsonSerializer.Deserialize<TModel>(body);
                @event(model);
                Consuming.Model.BasicAck(ea.DeliveryTag, true);
            };
            return this;
        }
        public void Consume()
        {
            Channel.BasicConsume(base.Queue, false, Consuming);
        }
    }
}