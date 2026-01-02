using Microsoft.EntityFrameworkCore;
using SellGold.Customers.Domain.Entities;
using SellGold.Customers.Domain.Exceptions;

namespace SellGold.Customers.Infrastructure.Data.Context
{
    public class SellGoldCustomersContext : DbContext
    {
        public SellGoldCustomersContext(DbContextOptions<SellGoldCustomersContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configuração para design-time (migrations)
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SellGoldCustomers;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");

                // Chave primária
                entity.HasKey(e => e.CustomerId);

                // Propriedades
                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever(); // Guid gerado pela aplicação

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Document)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.UpdatedAt)
                    .IsRequired();

                // Configurar a coleção de Addresses como propriedade owned
                // Address é um Value Object que contém outros Value Objects
                entity.OwnsMany(e => e.Addresses, address =>
                {
                    address.WithOwner().HasForeignKey("CustomerId");
                    address.ToTable("CustomerAddresses");

                    // Chave primária para a tabela
                    address.Property<int>("CustomerAddressesId")
                        .ValueGeneratedOnAdd();

                    address.HasKey("Id");

                    // Propriedades simples do Address
                    address.Property(a => a.ZipCode)
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnName("ZipCode");

                    address.Property(a => a.AddressType)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnName("AddressType");

                    // Configurar Value Object StreetInfo como propriedade owned DENTRO de Address
                    address.OwnsOne(a => a.StreetInfo, street =>
                    {
                        // Configurações do StreetInfo
                        street.Property(s => s.Street)
                            .IsRequired()
                            .HasMaxLength(200)
                            .HasColumnName("Street");

                        street.Property(s => s.Number)
                            .IsRequired()
                            .HasMaxLength(20)
                            .HasColumnName("Number");

                        street.Property(s => s.Complement)
                            .HasMaxLength(100)
                            .HasColumnName("Complement");
                    });

                    // Configurar Value Object Place como propriedade owned DENTRO de Address
                    address.OwnsOne(a => a.Location, place =>
                    {
                        // Configurações do Place
                        place.Property(p => p.District)
                            .IsRequired()
                            .HasMaxLength(100)
                            .HasColumnName("District");

                        place.Property(p => p.City)
                            .IsRequired()
                            .HasMaxLength(100)
                            .HasColumnName("City");

                        place.Property(p => p.State)
                            .IsRequired()
                            .HasMaxLength(50)
                            .HasColumnName("State");

                        place.Property(p => p.Country)
                            .IsRequired()
                            .HasMaxLength(50)
                            .HasColumnName("Country")
                            .HasDefaultValue("Brasil");
                    });

                    // Índices para Address
                    address.HasIndex("CustomerId");
                    address.HasIndex(a => a.ZipCode);
                });

                // Índices para Customer
                entity.HasIndex(e => e.Document)
                    .IsUnique();

                entity.HasIndex(e => e.Email);

                entity.HasIndex(e => e.IsActive);

                entity.HasIndex(e => e.CreatedAt);
            });

            // Configuração para ignorar DomainException (não é uma entidade)
            modelBuilder.Ignore<DomainException>();
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker
                .Entries<Customer>()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    // Para CreatedAt
                    var createdAtProp = entry.Property("CreatedAt");
                    if (createdAtProp != null)
                    {
                        createdAtProp.CurrentValue = DateTime.UtcNow;
                    }
                }

                // Para UpdatedAt (sempre atualizar)
                var updatedAtProp = entry.Property("UpdatedAt");
                if (updatedAtProp != null)
                {
                    updatedAtProp.CurrentValue = DateTime.UtcNow;
                }
            }
        }
    }
}