using Microsoft.EntityFrameworkCore;
using SellGold.Customers.Application.Interfaces.Repositories;
using SellGold.Customers.Domain.Entities;
using SellGold.Customers.Infrastructure.Data.Context;
using SellGold.Customers.Infrastructure.Exceptions;

namespace SellGold.Customers.Infrastructure.Repositories
{
    public class SellGoldCustomersRepository : ICustomersRepository
    {
        private readonly SellGoldCustomersContext _context;
        public SellGoldCustomersRepository(SellGoldCustomersContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public async Task<Customer?> GetByIdAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            return await _context.Customers
                        .Include(c => c.Addresses)
                        .FirstOrDefaultAsync(c => c.CustomerId == customerId, cancellationToken);

        }
        public async Task<IEnumerable<Customer>> GetAllAsync(string? cpf = null,
                                                                CancellationToken cancellationToken = default)
        {
            var query = _context.Customers.Include(c => c.Addresses).AsQueryable();

            if (!string.IsNullOrEmpty(cpf))
            {
                query = query.Where(c => c.Document == cpf);
            }

            return await query.ToListAsync(cancellationToken);
        }
        public async Task<Customer?> GetByCpfAsync(string? cpf = null, CancellationToken cancellationToken = default)
        {
            return await _context.Customers
                .Include(c => c.Addresses)
                .FirstOrDefaultAsync(c => c.Document == cpf, cancellationToken);
        }
        public async Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }
        public async Task DeleteAsync(Guid customerId, CancellationToken cancellationToken = default)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
