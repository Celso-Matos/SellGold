using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SellGold.Payments.Domain.Aggregates;

namespace SellGold.Payments.Infrastructure.Persistence.SQL.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(p => p.PaymentId);

            builder.Property(p => p.OrderId).IsRequired();
            
            builder.OwnsOne(p => p.Amount, money =>
            {
                money.Property(m => m.Value)
                     .HasColumnName("Amount")
                     .HasPrecision(18, 2);

                money.Property(m => m.Currency)
                     .HasColumnName("Currency")
                     .HasMaxLength(3);
            });

            
            builder.OwnsOne(p => p.PaymentMethod, method =>
            {
                method.Property(m => m.Type)
                      .HasColumnName("PaymentType")
                      .HasConversion<int>();

                method.Property(m => m.Provider)
                      .HasColumnName("PaymentProvider")
                      .HasMaxLength(100);
            });

            builder.Property(p => p.Status)
                   .HasConversion<int>();

            // Configuração da coleção Transactions
            builder.Metadata
                   .FindNavigation(nameof(Payment.Transactions))!
                   .SetPropertyAccessMode(PropertyAccessMode.Field);

            // Ignora eventos de domínio
            builder.Ignore(p => p.DomainEvents);
        }
    }
}