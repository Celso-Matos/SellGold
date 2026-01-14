using SellGold.Products.Domain.Entities;

namespace SellGold.Products.Application.Interfaces.Repositories
{
    public interface IProductsRepository
    {
        Task<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Product?> GetByNameAsync(string? name, CancellationToken cancellationToken = default);
        Task<Product?> GetByBarcodeAsync(string? barcode, CancellationToken cancellationToken = default);
        Task AddAsync(Product product, CancellationToken cancellationToken = default);
        Task UpdateAsync(Product product, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid productId, CancellationToken cancellationToken = default);
        
    }
}
