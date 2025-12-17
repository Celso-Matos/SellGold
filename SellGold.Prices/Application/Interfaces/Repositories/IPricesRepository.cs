using SellGold.Prices.Domain.Entities;


namespace SellGold.Prices.Application.Interfaces.Repositories
{
    public interface IPricesRepository
    {
        Task<Price> GetByIdAsync(Guid priceId);
        Task<IEnumerable<Price>> GetAllAsync();
        Task AddAsync(Price price);
        Task UpdateAsync(Price price);
        Task DeleteAsync(Guid priceId);
    }
}
