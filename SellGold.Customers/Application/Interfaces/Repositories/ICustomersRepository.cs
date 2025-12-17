using SellGold.Customers.Domain.Entities;
namespace SellGold.Customers.Application.Interfaces.Repositories
{
    public interface ICustomersRepository
    {
        Task<Customer> GetByIdAsync(Guid customerId);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid customerId);
    }
}
