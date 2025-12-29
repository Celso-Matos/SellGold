using Microsoft.EntityFrameworkCore;
using SellGold.Payments.Application.Interfaces.Repositories;
using SellGold.Payments.Domain.Entities;
using SellGold.Payments.Infrastructure.Data.Context;
using SellGold.Payments.Infrastructure.Exceptions;

namespace SellGold.Payments.Infrastructure.Repositories
{
    public class SellGoldPaymentsRepository : IPaymentsRepository
    {
        private readonly SellGoldPaymentsContext _context;
        public SellGoldPaymentsRepository(SellGoldPaymentsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Payment> GetByIdAsync(Guid paymentId)
        {
            return await _context.Payments
                                        .FirstOrDefaultAsync(p => p.PaymentId == paymentId) ?? throw new InfrastructureException($"Pagamento {paymentId} não encontrado.");
        }
        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments.ToListAsync();
        }
        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Payment payment)
        {
            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid paymentId)
        {
            var payment = await _context.Payments.FindAsync(paymentId);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
