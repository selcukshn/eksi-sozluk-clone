using RabbitMQ.Client;

namespace Common.Infrastructure.RabbitMQ
{
    public class BaseQueue
    {
        private IConnection Connection { get; set; }
        public bool HaveConnection => Connection != null && Connection.IsOpen;
        public IModel Channel { get; set; }
        public string Queue { get; set; }
        public string Exchange { get; set; }
        public string ExchangeType { get; set; }
        public string RoutingKey { get; set; }
        public BaseQueue(string queue)
        {
            Connection = new ConnectionFactory() { HostName = QueueConstants.Host }.CreateConnection();
            Channel = Connection.CreateModel();
            Queue = queue;
        }
        public BaseQueue(string exchange, string queue, string routingKey, string exchangeType = "direct")
        {
            Connection = new ConnectionFactory() { HostName = QueueConstants.Host }.CreateConnection();
            Channel = Connection.CreateModel();
            Queue = queue;
            Exchange = exchange;
            RoutingKey = routingKey;
            ExchangeType = exchangeType;
        }
        protected BaseQueue QueueDeclare(bool durable = false, bool exclusive = false, bool autoDelete = false)
        {
            Channel.QueueDeclare(this.Queue, durable, exclusive, autoDelete);
            return this;
        }
        protected BaseQueue ExchangeDeclare()
        {
            Channel.ExchangeDeclare(this.Exchange, this.ExchangeType);
            return this;
        }
        protected BaseQueue BindQueue()
        {
            Channel.QueueBind(this.Queue, this.Exchange, this.RoutingKey);
            return this;
        }
        protected void AutoDeclare()
        {
            this.ExchangeDeclare().QueueDeclare().BindQueue();
        }
    }
}