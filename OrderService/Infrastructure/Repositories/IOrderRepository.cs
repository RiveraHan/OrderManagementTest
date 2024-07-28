using OrderService.Domain.Models;


namespace OrderService.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(Guid orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
    }
}
