using MediatR;
using OrderService.Commands;
using OrderService.Domain.Models;
using OrderService.Infrastructure.Repositories;
using OrderService.Infrastructure.MessageBus;


namespace OrderService.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMessageBus _messageBus;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMessageBus messageBus)
        {
            _orderRepository = orderRepository;
            _messageBus = messageBus;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(request.ProductName, request.Quantity);
            await _orderRepository.AddOrderAsync(order);

            await _messageBus.Publish("order-created", new { OrderId = order.Id });

            return order.Id;
        }
    }
}
