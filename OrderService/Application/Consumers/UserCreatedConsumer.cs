using MassTransit;
using OrderService.Application.Events;

namespace OrderService.Application.Consumers
{
    public class UserCreatedConsumer : IConsumer<UserCreatedEvent>
    {
        public Task Consume(ConsumeContext<UserCreatedEvent> context)
        {
            var message = context.Message;
            // Manejar el evento (e.g., loguear, crear una orden para el usuario, etc.)
            Console.WriteLine($"User created: {message.UserId}, {message.UserName}");
            return Task.CompletedTask;
        }
    }
}
