using SellGold.Stock.Domain.Entities;

namespace SellGold.Stock.Application.Interfaces.Repositories
{
    public interface IStockRepository
    {
        Task<StockProduct> GetByIdAsync(Guid stockProductId);
        Task<IEnumerable<StockProduct>> GetAllAsync();
        Task AddAsync(StockProduct stockProduct);
        Task UpdateAsync(StockProduct stockProduct);
        Task DeleteAsync(Guid stockProductId);
    }
}
