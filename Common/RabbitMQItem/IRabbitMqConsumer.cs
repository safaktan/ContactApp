using RabbitMQ.Client;
namespace Common.RabbitMQItem
{
    public interface IRabbitMqConsumer
    {
        void Consume(string queueName, Func<string, Task> onMessageReceived);
    } 
}