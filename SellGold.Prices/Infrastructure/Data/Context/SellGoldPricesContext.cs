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
        public DbSet<PriceProduct> PriceProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Price>()
            .OwnsOne(p => p.BasePrice);

            // Tabela intermediária PriceProduct
            modelBuilder.Entity<PriceProduct>(entity =>
            {
                // Chave composta
                entity.HasKey(pp => new { pp.PriceId, pp.ProductId });

                // Relação com Price (FK física)
                entity.HasOne(pp => pp.Price)
                      .WithMany(p => p.PriceProducts)
                      .HasForeignKey(pp => pp.PriceId);

                // ProductId é apenas referência (sem navegação EF)
                entity.Property(pp => pp.ProductId)
                      .IsRequired();
            });

        }
    }
}
