using SellGold.Stock.Application.Interfaces.Repositories;
using SellGold.Stock.Infrastructure.Data.Context;
using SellGold.Stock.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;

namespace SellGold.Stock.Infrastructure.Repositories
{
    public class SellGoldStockRepository : IStockRepository
    {
        private readonly SellGoldStockContext _context;

        public SellGoldStockRepository(SellGoldStockContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddAsync(StockProduct stockProduct)
        {
            await _context.StockProduct.AddAsync(stockProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid stockProductId)
        {
            var stockProduct = await _context.StockProduct.FindAsync(stockProductId);
            if (stockProduct != null)
            {
                _context.StockProduct.Remove(stockProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<StockProduct>> GetAllAsync()
        {
            return await _context.StockProduct
                            .Include(m => m.StockMovement)
                            .Include(l => l.StockLocation)
                            .ToListAsync();
        }

        public async Task<StockProduct> GetByIdAsync(Guid stockProductId)
        {
            return await _context.StockProduct
                            .Include(m => m.StockMovement)
                            .Include(l => l.StockLocation)
                            .FirstOrDefaultAsync(m => m.StockProductId == stockProductId) ?? throw new KeyNotFoundException($"Produto {stockProductId} não encontrado no estoque.");
        }
        public async Task UpdateAsync(StockProduct stockProduct)
        {
            _context.Entry(stockProduct).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
