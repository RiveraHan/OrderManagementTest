using MediatR;
using OrderService.Domain.Models;

namespace OrderService.Application.Queries
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {
    }
}
