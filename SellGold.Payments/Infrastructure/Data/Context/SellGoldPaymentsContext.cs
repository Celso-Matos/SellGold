using Microsoft.EntityFrameworkCore;
using SellGold.Payments.Domain.Entities;

namespace SellGold.Payments.Infrastructure.Data.Context
{
    public class SellGoldPaymentsContext : DbContext
    {
        public SellGoldPaymentsContext(DbContextOptions<SellGoldPaymentsContext> options) : base(options)
        {
        }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<PaymentMethod> PaymentMethod { get; set; }

        public DbSet<Invoice> Invoice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().OwnsOne(p => p.Amount);
            modelBuilder.Entity<Invoice>().OwnsOne(i => i.Amount);
        }
    }
}
