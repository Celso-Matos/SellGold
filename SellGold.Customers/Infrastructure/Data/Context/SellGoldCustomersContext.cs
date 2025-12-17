using Microsoft.EntityFrameworkCore;
using SellGold.Customers.Domain.Entities;
using SellGold.Customers.Domain.ValueObject;
namespace SellGold.Customers.Infrastructure.Data.Context
{
    public class SellGoldCustomersContext : DbContext
    {
        public SellGoldCustomersContext(DbContextOptions<SellGoldCustomersContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
