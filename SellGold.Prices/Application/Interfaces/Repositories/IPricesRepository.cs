using SellGold.Prices.Domain.Entities;


namespace SellGold.Prices.Application.Interfaces.Repositories
{
    public interface IPricesRepository
    {
        Task<Price?> GetByIdAsync(Guid priceId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Price>> GetAllAsync();
        Task<IEnumerable<PriceProduct?>> GetPriceProductsByProductIdAsync(Guid productId, CancellationToken cancellationToken = default);
        Task AddAsync(Price price);
        Task UpdateAsync(Price price);
        Task DeleteAsync(Guid priceId);
    }
}
