using Microsoft.EntityFrameworkCore;
using SellGold.Prices.Application.Interfaces.Repositories;
using SellGold.Prices.Domain.Entities;
using SellGold.Prices.Infrastructure.Data.Context;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;

namespace SellGold.Prices.Infrastructure.Repositories
{
    public class SellGoldPricesRepository : IPricesRepository
    {
        private readonly SellGoldPricesContext _context;
        public SellGoldPricesRepository(SellGoldPricesContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Price> GetByIdAsync(Guid priceId)
        {
            return await _context.Prices
                                        .FirstOrDefaultAsync(p => p.PriceId == priceId) ?? throw new KeyNotFoundException($"Preço {priceId} não encontrado.");
        }
        public async Task<IEnumerable<Price>> GetAllAsync()
        {
            return await _context.Prices.ToListAsync();
        }
        public async Task AddAsync(Price price)
        {
            await _context.Prices.AddAsync(price);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Price price)
        {
            _context.Entry(price).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid priceId)
        {
            var price = await _context.Prices.FindAsync(priceId);
            if (price != null)
            {
                _context.Prices.Remove(price);
                await _context.SaveChangesAsync();
            }
        }
    }
}
