using Microsoft.EntityFrameworkCore;
using SellGold.Promotions.Application.Interfaces.Repositories;
using SellGold.Promotions.Domain.Entities;
using SellGold.Promotions.Infrastructure.Data.Context;
using SellGold.Promotions.Infrastructure.Exceptions;

namespace SellGold.Promotions.Infrastructure.Repositories
{
    public class SellGoldPromotionsRepository : IPromotionsRepository
    {
        private readonly SellGoldPromotionsContext _context;
        public SellGoldPromotionsRepository(SellGoldPromotionsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Promotion> GetByIdAsync(Guid promotionId, CancellationToken cancellationToken)
        {
            return await _context.Promotions
                            .FirstOrDefaultAsync(p => p.PromotionId == promotionId) ?? throw new InfrastructureException($"Promoção {promotionId} não encontrada.");
        }
        public async Task<IEnumerable<Promotion>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Promotions.ToListAsync();
        }
        public async Task AddAsync(Promotion promotion, CancellationToken cancellationToken)
        {
            await _context.Promotions.AddAsync(promotion);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Promotion promotion, CancellationToken cancellationToken)
        {
            _context.Entry(promotion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid promotionId, CancellationToken cancellationToken)
        {
            var promotion = await _context.Promotions.FindAsync(promotionId);
            if (promotion != null)
            {
                _context.Promotions.Remove(promotion);
                await _context.SaveChangesAsync();
            }
        }   
    }
}
