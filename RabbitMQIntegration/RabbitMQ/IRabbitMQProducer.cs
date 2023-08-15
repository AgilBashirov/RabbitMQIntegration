namespace RabbitMQIntegration.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        public void SendMessage(string message);
        public string ReceiveMessage();


    }
}
