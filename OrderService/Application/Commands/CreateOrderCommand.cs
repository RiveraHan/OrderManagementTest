using MediatR;
using OrderService.Data;
using OrderService.Models;

namespace OrderService.Application.Commands
{
    public record CreateOrderCommand(int UserId, List<OrderItem> Items) : IRequest<int>;

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly OrderDbContext _context;

        public CreateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order { UserId = request.UserId, Items = request.Items };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);
            return order.Id;
        }
    }
}
