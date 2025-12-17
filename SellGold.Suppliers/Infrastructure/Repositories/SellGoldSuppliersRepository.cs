using Microsoft.EntityFrameworkCore;
using SellGold.Suppliers.Application.Interfaces.Repositories;
using SellGold.Suppliers.Domain.Entities;
using SellGold.Suppliers.Infrastructure.Data.Context;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;

namespace SellGold.Suppliers.Infrastructure.Repositories
{
    public class SellGoldSuppliersRepository : ISupplierRepository
    {
        private readonly SellGoldSupplierContext _context;

        public SellGoldSuppliersRepository(SellGoldSupplierContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Supplier> GetByIdAsync(Guid supplierId)
        {
            return await _context.Suppliers
                                        .Include(p => p.Addresses)
                                        .FirstOrDefaultAsync(p => p.SupplierId == supplierId) ?? throw new KeyNotFoundException($"Produto {supplierId} não encontrado.");

        }

        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return await _context.Suppliers.Include(p => p.Addresses).ToListAsync();
        }

        public async Task AddAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            _context.Entry(supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid supplierId)
        {
            var supplier = await _context.Suppliers.FindAsync(supplierId);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }
        }       


    }
}
