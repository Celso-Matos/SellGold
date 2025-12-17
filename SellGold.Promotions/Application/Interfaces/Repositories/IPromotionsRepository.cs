using SellGold.Promotions.Domain.Entities;
namespace SellGold.Promotions.Application.Interfaces.Repositories
{
    public interface IPromotionsRepository
    {
        Task<Promotion> GetByIdAsync(Guid promotionId);
        Task<IEnumerable<Promotion>> GetAllAsync();
        Task AddAsync(Promotion promotion);
        Task UpdateAsync(Promotion promotion);
        Task DeleteAsync(Guid promotionId);
    }
}
