using MediatR;
using OrderService.Application.Queries;
using OrderService.Domain.Models;
using OrderService.Infrastructure.Repositories;

namespace OrderService.Application.Handlers
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAllOrdersAsync();
        }
    }
}
