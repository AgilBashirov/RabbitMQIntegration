using RabbitMQ.Client;
using System.Text;

namespace RabbitMQIntegration.RabbitMQ
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        private readonly ConnectionFactory _connectionFactory;
        public RabbitMQProducer()
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };
        }
        public string ReceiveMessage()
        {
            using (var connection = _connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "id_queue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                BasicGetResult result = channel.BasicGet("id_queue", true);

                if (result != null)
                {
                    byte[] body = result.Body.ToArray();
                    return Encoding.UTF8.GetString(body);
                }

                return null; // No message available
            }
        }

        public void SendMessage(string message)
        {
            using (var connection = _connectionFactory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "id_queue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                    routingKey: "id_queue",
                    basicProperties: null,
                    body: body);
            }
        }
    }
}
