using RabbitMQ.Client;

namespace Common.Infrastructure.RabbitMQ
{
    public class BaseQueue
    {
        private IConnection Connection { get; set; }
        public bool HaveConnection => Connection != null && Connection.IsOpen;
        public IModel Channel { get; set; }
        public string Queue { get; set; }
        public BaseQueue(string queue)
        {
            Connection = new ConnectionFactory() { HostName = QueueConstants.Host }.CreateConnection();
            Channel = Connection.CreateModel();
            Queue = queue;
        }
    }
}