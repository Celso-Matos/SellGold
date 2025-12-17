using SellGold.Orders.Domain.Entities;
namespace SellGold.Orders.Application.Interfaces.Repositories
{
    public interface IOrdersRepository
    {
        Task<Order> GetByIdAsync(Guid orderId);
        Task<IEnumerable<Order>> GetAllAsync();
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Guid orderId);
    }
}
