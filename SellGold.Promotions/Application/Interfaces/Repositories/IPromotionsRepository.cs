using SellGold.Promotions.Domain.Entities;
namespace SellGold.Promotions.Application.Interfaces.Repositories
{
    public interface IPromotionsRepository
    {
        Task<Promotion> GetByIdAsync(Guid promotionId, CancellationToken cancellationToken);
        Task<IEnumerable<Promotion>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(Promotion promotion, CancellationToken cancellationToken);
        Task UpdateAsync(Promotion promotion, CancellationToken cancellationToken);
        Task DeleteAsync(Guid promotionId, CancellationToken cancellationToken);
    }
}
