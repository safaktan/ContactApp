using System.Text;
using System.Text.Json;
using Common.Constants;
using Common.DTOs;
using Common.Models;
using Common.RabbitMQItem;
using ContactService.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ContactService.Messaging
{
    public class ReportRequestConsumer : BackgroundService
    {
        private readonly IRabbitMqProducer<ReportGeneratedDto> _rabbitMqProducer;
        // private readonly IContactDetailService _contactDetailService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IModel _channel;
        private readonly string _queueName = EventNames.ReportRequested;

        public ReportRequestConsumer(IRabbitMqProducer<ReportGeneratedDto> rabbitMqProducer, IServiceProvider serviceProvider)
        {
            _rabbitMqProducer = rabbitMqProducer;
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _channel.QueueDeclare(queue: _queueName,
                         durable: true,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);
                         
            var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            var message = Encoding.UTF8.GetString(ea.Body.ToArray());
            var request = JsonSerializer.Deserialize<RabbitMqRequestDto>(message);

            var resportResultDto = new ServiceResponse<List<ReportResultDto>>();
            using(var scope = _serviceProvider.CreateScope())
            {
                var contactDetailService = scope.ServiceProvider.GetRequiredService<IContactDetailService>();
                resportResultDto = await contactDetailService.GetReportDataByLocationAsync();
            }

            var report = new ReportGeneratedDto
            {
                ReportId = request.ReportId,
                ReportResultDtoList = resportResultDto.Data
            };

            _rabbitMqProducer.Publish(EventNames.ReportGenerated, report);

            _channel.BasicAck(ea.DeliveryTag, false);
        };

        _channel.BasicConsume(queue: _queueName, autoAck: false, consumer: consumer);

        return Task.CompletedTask;
        }
    }
}