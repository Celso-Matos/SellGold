using Microsoft.EntityFrameworkCore;
using SellGold.Prices.Domain.Entities;

namespace SellGold.Prices.Infrastructure.Data.Context
{
    public class SellGoldPricesContext : DbContext
    {
        public SellGoldPricesContext(DbContextOptions<SellGoldPricesContext> options) : base(options)
        {
        }
        public DbSet<Price> Prices { get; set; }
        public DbSet<PriceDiscount> PriceDiscounts { get; set; }
        public DbSet<PriceTax> PriceTaxes { get; set; }
        public DbSet<PricePolicy> PricePolicies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Price>()
            .OwnsOne(p => p.BasePrice);

        }
    }
}
