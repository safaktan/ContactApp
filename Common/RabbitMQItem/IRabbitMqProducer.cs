using RabbitMQ.Client;
namespace Common.RabbitMQItem
{
    public interface IRabbitMqProducer<T>
    {
        void Publish(string queueName, T message);
    }
    
}