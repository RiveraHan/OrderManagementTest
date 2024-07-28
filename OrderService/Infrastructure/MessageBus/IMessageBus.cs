namespace OrderService.Infrastructure.MessageBus
{
    public interface IMessageBus
    {
        Task Publish(string topic, object message);
    }
}
