using SellGold.Products.Domain.Entities;

namespace SellGold.Products.Application.Interfaces.Repositories
{
    public interface IProductsRepository
    {
        Task<Product> GetByIdAsync(Guid productId);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid productId);
        Task<Product> GetByProductBarcodeAsync(string barcode);
    }
}
