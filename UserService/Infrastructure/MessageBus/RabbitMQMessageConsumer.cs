using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
namespace UserService.Infrastructure.MessageBus
{
    public class RabbitMQMessageConsumer : BackgroundService
    {
        private readonly string _hostname;
        private readonly string _queueName;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQMessageConsumer(string hostname, string queueName)
        {
            _hostname = hostname;
            _queueName = queueName;
            InitializeRabbitMQListener();
        }

        private void InitializeRabbitMQListener()
        {
            var factory = new ConnectionFactory() { HostName = _hostname };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                HandleMessage(content);
                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(_queueName, false, consumer);
            return Task.CompletedTask;
        }

        private void HandleMessage(string content)
        {
            var message = JsonSerializer.Deserialize<dynamic>(content);
            Console.WriteLine($"Received message: {message}");
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}

