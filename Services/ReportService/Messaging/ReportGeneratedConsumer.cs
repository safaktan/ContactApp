using System.Text;
using System.Text.Json;
using Common.Constants;
using Common.DTOs;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReportService.Services;

namespace ReportService.Messaging
{
    public class ReportGeneratedConsumer : BackgroundService
    {
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;
        private readonly string _queueName = EventNames.ReportGenerated;

        public ReportGeneratedConsumer(IServiceProvider serviceProvider)
        {
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
            var reportData = JsonSerializer.Deserialize<ReportGeneratedDto>(message);

            using(var scope = _serviceProvider.CreateScope())
            {
                var reportService = scope.ServiceProvider.GetRequiredService<IReportService>();
                var reportDetailService = scope.ServiceProvider.GetRequiredService<IReportDetailService>();

                await reportDetailService.SaveReportDetailAsync(reportData);
                await reportService.UpdateReportStatusByIdAsync(reportData.ReportId, ReportStatus.ReportDone);

            }
            
            _channel.BasicAck(ea.DeliveryTag, false);
        };

        _channel.BasicConsume(queue: _queueName, autoAck: false, consumer: consumer);

        return Task.CompletedTask;
    }
    }

}