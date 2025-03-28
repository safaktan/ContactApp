using System.Text;
using System.Text.Json;
using RabbitMQ.Client;


namespace Common.RabbitMQItem
{
    public class RabbitMqProducer<T> : IRabbitMqProducer<T>
    {
        private IConnection _connection;
        private RabbitMQ.Client.IModel _channel;

        public RabbitMqProducer()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void Publish(string queueName, T message)
        {
            _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
            _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
        }
    }
}