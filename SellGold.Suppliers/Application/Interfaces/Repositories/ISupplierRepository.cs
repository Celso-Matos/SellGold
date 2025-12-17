using SellGold.Suppliers.Domain.Entities;

namespace SellGold.Suppliers.Application.Interfaces.Repositories
{
    public interface ISupplierRepository
    {
        Task<Supplier> GetByIdAsync(Guid supplierId);
        Task<IEnumerable<Supplier>> GetAllAsync();
        Task AddAsync(Supplier supplier);
        Task UpdateAsync(Supplier supplier);
        Task DeleteAsync(Guid supplierId);        
    }
}
