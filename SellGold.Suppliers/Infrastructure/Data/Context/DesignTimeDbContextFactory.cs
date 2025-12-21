using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SellGold.Suppliers.Infrastructure.Data.Context;

namespace SellGold.Suppliers.Infrastructure.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SellGoldSuppliersContext>
    {
        public SellGoldSuppliersContext CreateDbContext(string[] args)
        {
            // Configuração simples apenas para migrations
            var optionsBuilder = new DbContextOptionsBuilder<SellGoldSuppliersContext>();

            // Use a mesma string de conexão do seu appsettings.json
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=SellGoldSuppliers;Trusted_Connection=True;MultipleActiveResultSets=true";

            optionsBuilder.UseSqlServer(connectionString,
                sqlOptions => sqlOptions.MigrationsAssembly("SellGold.Suppliers"));

            return new SellGoldSuppliersContext(optionsBuilder.Options);
        }
    }
}