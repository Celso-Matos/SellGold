using Microsoft.EntityFrameworkCore;
using SellGold.Products.Domain.Entities;

namespace SellGold.Products.Infrastructure.Data.Context
{
    public class SellGoldProductsContext: DbContext
    {
        public SellGoldProductsContext(DbContextOptions<SellGoldProductsContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBarcode> ProductBarcodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Products", schema: "dbo");

            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<ProductBarcode>()
                .ToTable("ProductsBarcodes", schema: "dbo");

            modelBuilder.Entity<ProductBarcode>()
                .HasKey(pb => pb.BarcodeId);

            modelBuilder.Entity<ProductBarcode>()
                .HasIndex(p => p.Barcode)
                .IsUnique();

            
            modelBuilder.Entity<ProductBarcode>()
                .HasOne(pb => pb.Product)
                .WithMany(p => p.Barcode)
                .HasForeignKey(pb => pb.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
