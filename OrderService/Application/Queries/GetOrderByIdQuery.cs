using MediatR;
using OrderService.Domain.Models;

namespace OrderService.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public Guid OrderId { get; set; }
    }
}