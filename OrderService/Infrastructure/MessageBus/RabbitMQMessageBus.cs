using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace OrderService.Infrastructure.MessageBus
{
    public class RabbitMQMessageBus : IMessageBus
    {
        private readonly string _hostname;
        private readonly string _queueName;

        public RabbitMQMessageBus(string hostname, string queueName)
        {
            _hostname = hostname;
            _queueName = queueName;
        }

        public async Task Publish(string topic, object message)
        {
            var factory = new ConnectionFactory() { HostName = _hostname };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
            await Task.CompletedTask;
        }
    }
}
