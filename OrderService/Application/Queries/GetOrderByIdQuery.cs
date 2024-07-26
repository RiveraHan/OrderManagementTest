using MediatR;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;

namespace OrderService.Application.Queries
{
    public record GetOrderByIdQuery(int Id) : IRequest<Order>;

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly OrderDbContext _context;

        public GetOrderByIdQueryHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);
        }
    }
}