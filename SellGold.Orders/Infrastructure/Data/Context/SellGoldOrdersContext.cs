using Microsoft.EntityFrameworkCore;
using SellGold.Orders.Domain.Entities;
namespace SellGold.Orders.Infrastructure.Data.Context
{
    public class SellGoldOrdersContext : DbContext
    {
        public SellGoldOrdersContext(DbContextOptions<SellGoldOrdersContext> options) : base(options)
        {
        }

        public DbSet<OrderRequest> Orders { get; set; }

        public DbSet<OrderItemRedponse> OrderItems { get; set; }

    }
    
}
