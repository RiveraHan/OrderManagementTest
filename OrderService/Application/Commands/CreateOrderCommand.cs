using MediatR;

namespace OrderService.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public required string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
