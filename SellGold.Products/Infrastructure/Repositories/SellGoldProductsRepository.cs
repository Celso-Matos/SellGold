using Microsoft.EntityFrameworkCore;
using SellGold.Products.Application.Interfaces.Repositories;
using SellGold.Products.Domain.Entities;
using SellGold.Products.Infrastructure.Data.Context;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;


namespace SellGold.Products.Infrastructure.Repositories
{
    public class SellGoldProductsRepository : IProductsRepository
    {
        private readonly SellGoldProductsContext _context;

        public SellGoldProductsRepository(SellGoldProductsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        
        }
        public async Task<Product> GetByIdAsync(Guid productId)
        {
            return await _context.Products
                                        .Include(p => p.Barcode)
                                        .FirstOrDefaultAsync(p => p.ProductId == productId) ?? throw new KeyNotFoundException($"Produto {productId} não encontrado.");
            
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(p => p.Barcode).ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Product> GetByProductBarcodeAsync(string barcode)
        {
            return await _context.ProductBarcodes
                            .Where(pb => pb.Barcode == barcode)
                            .Select(pb => pb.Product)
                            .Include(pb => pb.Barcode)
                            .SingleOrDefaultAsync() ?? throw new KeyNotFoundException($"Produto {barcode} não encontrado.");            
        }
    }
}
