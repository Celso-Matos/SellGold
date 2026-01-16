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
        public async Task<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            return await _context.Products
                                        .Include(p => p.Barcode)
                                        .FirstOrDefaultAsync(p => p.ProductId == productId, cancellationToken);
            
        }

        public async Task<Product?> GetByNameAsync(string? name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            // Monta o padrão: contém o texto informado
            var pattern = $"%{name}%";

            return await _context.Products
                                        .Include(p => p.Barcode)
                                        .FirstOrDefaultAsync(p => EF.Functions.Like(p.Name, pattern), cancellationToken);
        }
        public async Task<Product?> GetByBarcodeAsync(string? barcode, CancellationToken cancellationToken = default)
        {
            return await _context.ProductBarcodes
                            .Where(pb => pb.Barcode == barcode)
                            .Select(pb => pb.Product)
                            .Include(pb => pb.Barcode)
                            .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Products.Include(p => p.Barcode).ToListAsync(cancellationToken);
        }

        public async Task AddAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
        
    }
}
