using SellGold.Orders.Domain.Entities;
namespace SellGold.Orders.Application.Interfaces.Repositories
{
    public interface IOrdersRepository
    {
        Task<OrderRequest> GetByIdAsync(Guid orderId);
        Task<IEnumerable<OrderRequest>> GetAllAsync();
        Task AddAsync(OrderRequest order);
        Task UpdateAsync(OrderRequest order);
        Task DeleteAsync(Guid orderId);
    }
}
