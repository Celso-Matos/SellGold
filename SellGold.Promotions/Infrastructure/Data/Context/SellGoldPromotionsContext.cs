using Microsoft.EntityFrameworkCore;
using SellGold.Promotions.Domain.Entities;
namespace SellGold.Promotions.Infrastructure.Data.Context
{
    public class SellGoldPromotionsContext : DbContext
    {
        public SellGoldPromotionsContext(DbContextOptions<SellGoldPromotionsContext> options) : base(options)
        {
        }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<LoyaltyAccount> LoyaltyAccount { get; set; }
        public DbSet<CashbackAccount> CashbackAccount { get; set; }

    }
}
