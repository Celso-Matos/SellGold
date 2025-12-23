using Microsoft.EntityFrameworkCore;
using SellGold.Payments.Domain.Aggregates;
using SellGold.Payments.Domain.Entities;

namespace SellGold.Payments.Infrastructure.Persistence.SQL.Data.Context
{
    public class SellGoldPaymentsContext : DbContext
    {
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<PaymentTransaction> PaymentTransactions => Set<PaymentTransaction>();

        public SellGoldPaymentsContext(DbContextOptions<SellGoldPaymentsContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SellGoldPaymentsContext).Assembly);
        }
    }
}
