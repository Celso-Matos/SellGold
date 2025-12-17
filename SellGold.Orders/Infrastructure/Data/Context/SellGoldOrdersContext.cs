using Microsoft.EntityFrameworkCore;
using SellGold.Orders.Domain.Entities;
namespace SellGold.Orders.Infrastructure.Data.Context
{
    public class SellGoldOrdersContext : DbContext
    {
        public SellGoldOrdersContext(DbContextOptions<SellGoldOrdersContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

    }
    
}
