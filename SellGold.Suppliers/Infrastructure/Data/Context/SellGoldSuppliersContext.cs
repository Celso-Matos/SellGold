using Microsoft.EntityFrameworkCore;
using SellGold.Suppliers.Domain.Entities;
using SellGold.Suppliers.Domain.Exceptions;
using SellGold.Suppliers.Domain.ValueObjects;

namespace SellGold.Suppliers.Infrastructure.Data.Context
{
    public class SellGoldSuppliersContext : DbContext
    {
        public SellGoldSuppliersContext(DbContextOptions<SellGoldSuppliersContext> options)
            : base(options)
        {
        }       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configuração para design-time (migrations)
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SellGoldSuppliers;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Supplier
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Suppliers");

                // Chave primária
                entity.HasKey(e => e.SupplierId);

                // Propriedades
                entity.Property(e => e.SupplierId)
                    .ValueGeneratedNever(); // Guid gerado pela aplicação

                entity.Property(e => e.CorporateName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TradeName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(18);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.StateRegistration)
                    .HasMaxLength(20);

                entity.Property(e => e.IsActive)
                    .IsRequired();

                entity.Property(e => e.CreatedAt)
                    .IsRequired();

                entity.Property(e => e.UpdatedAt)
                    .IsRequired();

                // Configurar a coleção de Addresses como propriedade owned
                // Address é um Value Object que contém outros Value Objects
                entity.OwnsMany(e => e.Addresses, address =>
                {
                    address.WithOwner().HasForeignKey("SupplierId");
                    address.ToTable("SupplierAddresses");

                    // Chave primária para a tabela
                    address.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    address.HasKey("Id");

                    // Propriedades simples do Address
                    address.Property(a => a.ZipCode)
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnName("ZipCode");

                    address.Property(a => a.Type)
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
                    address.HasIndex("SupplierId");
                    address.HasIndex(a => a.ZipCode);

                    // Configurar que Address é um Value Object (comparação por valor)
                    // O EF Core precisa saber como comparar Addresses
                    address.Property<string>("StreetInfo_Street"); // Shadow properties para ajudar
                    address.Property<string>("Location_City");
                });

                // Índices para Supplier
                entity.HasIndex(e => e.Cnpj)
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
                .Entries<Supplier>()
                .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            foreach (var entry in entries)
            {
                var supplier = entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    // Para CreatedAt, precisamos usar reflection pois é private set
                    var createdAtProp = entry.Property("CreatedAt");
                    if (createdAtProp != null)
                    {
                        createdAtProp.CurrentValue = DateTime.UtcNow;
                    }
                }

                // Para UpdatedAt
                var updatedAtProp = entry.Property("UpdatedAt");
                if (updatedAtProp != null)
                {
                    updatedAtProp.CurrentValue = DateTime.UtcNow;
                }
            }
        }
    }
}