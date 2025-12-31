using SellGold.Customers.Domain.Entities;
namespace SellGold.Customers.Application.Interfaces.Repositories
{
    public interface ICustomersRepository
    {
        Task<Customer> GetByIdAsync(Guid customerId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Customer>> GetAllAsync(string? cpf = null, CancellationToken cancellationToken = default);
        Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
        Task UpdateAsync(Customer customer, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid customerId, CancellationToken cancellationToken = default);
    }
}
