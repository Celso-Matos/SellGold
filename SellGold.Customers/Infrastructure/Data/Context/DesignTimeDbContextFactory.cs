using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SellGold.Customers.Infrastructure.Data.Context;

namespace SellGold.Customers.Infrastructure.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SellGoldCustomersContext>
    {
        public SellGoldCustomersContext CreateDbContext(string[] args)
        {
            // Configuração simples apenas para migrations
            var optionsBuilder = new DbContextOptionsBuilder<SellGoldCustomersContext>();

            // Use a mesma string de conexão do seu appsettings.json
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=SellGoldCustomers;Trusted_Connection=True;MultipleActiveResultSets=true";

            optionsBuilder.UseSqlServer(connectionString,
                sqlOptions => sqlOptions.MigrationsAssembly("SellGold.Customers"));

            return new SellGoldCustomersContext(optionsBuilder.Options);
        }
    }
}