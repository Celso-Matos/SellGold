using Microsoft.EntityFrameworkCore;
using SellGold.Stock.Domain.Entities;

namespace SellGold.Stock.Infrastructure.Data.Context
{
    public class SellGoldStockContext : DbContext
    {
        public SellGoldStockContext(DbContextOptions<SellGoldStockContext> options) : base(options)
        {
            
        }

        public DbSet<StockProduct> StockProduct { get; set; }

        public DbSet<StockLocation> StockLocation { get; set; }

        public DbSet<StockMovement> StockMovement { get; set; }

        public DbSet<Address> Addresses { get; set; }        


    }
}
