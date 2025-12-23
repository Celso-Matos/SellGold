using SellGold.Payments.Domain.Aggregates;

namespace SellGold.Payments.Application.Interfaces.Repositories
{
    public interface IPaymentsRepository
    {
        Task<Payment> GetByIdAsync(Guid paymentId);
        Task<IEnumerable<Payment>> GetAllAsync();
        Task AddAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task DeleteAsync(Guid paymentId);
    }
}
