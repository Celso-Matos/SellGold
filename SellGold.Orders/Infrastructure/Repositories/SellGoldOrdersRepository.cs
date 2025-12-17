using Microsoft.EntityFrameworkCore;
using SellGold.Orders.Application.Interfaces.Repositories;
using SellGold.Orders.Domain.Entities;
using SellGold.Orders.Infrastructure.Data.Context;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;

namespace SellGold.Orders.Infrastructure.Repositories
{
    public class SellGoldOrdersRepository : IOrdersRepository
    {
        private readonly SellGoldOrdersContext _context;
        public SellGoldOrdersRepository(SellGoldOrdersContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Order> GetByIdAsync(Guid orderId)
        {
            return await _context.Orders
                                        .Include(o => o.OrderItems)
                                        .FirstOrDefaultAsync(o => o.OrderId == orderId) ?? throw new KeyNotFoundException($"Pedido {orderId} não encontrado.");
        }
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.Include(o => o.OrderItems).ToListAsync();
        }
        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}
