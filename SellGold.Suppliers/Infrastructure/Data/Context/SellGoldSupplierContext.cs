using Microsoft.EntityFrameworkCore;
using SellGold.Suppliers.Domain.Entities;

namespace SellGold.Suppliers.Infrastructure.Data.Context
{
    public class SellGoldSupplierContext : DbContext
    {
        public SellGoldSupplierContext(DbContextOptions<SellGoldSupplierContext> options) : base(options)
        {

        }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
