using Microsoft.EntityFrameworkCore;
using SellGold.Customers.Application.Interfaces.Repositories;
using SellGold.Customers.Domain.Entities;
using SellGold.Customers.Infrastructure.Data.Context;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;

namespace SellGold.Customers.Infrastructure.Repositories
{
    public class SellGoldCustomersRepository : ICustomersRepository
    {
        private readonly SellGoldCustomersContext _context;
        public SellGoldCustomersRepository(SellGoldCustomersContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<Customer> GetByIdAsync(Guid customerId)
        {
            return await _context.Customers
                                        .Include(c => c.Addresses)
                                        .FirstOrDefaultAsync(c => c.CustomerId == customerId) ?? throw new KeyNotFoundException($"Cliente {customerId} não encontrado.");

        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customers.Include(c => c.Addresses).ToListAsync();
        }
        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
