using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SellGold.Payments.Domain.Aggregates;
using SellGold.Payments.Domain.Entities;
using SellGold.Payments.Domain.ValueObjects;

namespace SellGold.Payments.Infrastructure.Persistence.SQL.Configurations
{
    public class PaymentTransactionConfiguration
        : IEntityTypeConfiguration<PaymentTransaction>
    {
        public void Configure(EntityTypeBuilder<PaymentTransaction> builder)
        {
            builder.ToTable("PaymentTransactions");

            builder.HasKey(t => t.PaymentTransactionId);

            builder.Property(t => t.Type)
                   .HasConversion<int>()
                   .IsRequired();

            builder.Property(t => t.Status)
                   .HasConversion<int>()
                   .IsRequired();

            builder.Property(t => t.OccurredAt)
                   .IsRequired();

            builder.HasOne<Payment>()
                   .WithMany(p => p.Transactions)
                   .HasForeignKey("PaymentId")
                   .OnDelete(DeleteBehavior.Cascade);

            builder.OwnsOne(t => t.CardInfo, card =>
            {
                card.Property(c => c.Last4Digits)
                    .HasColumnName("CardLast4Digits")
                    .HasMaxLength(4);

                card.Property(c => c.Brand)
                    .HasColumnName("CardBrand")
                    .HasMaxLength(50);
            });
        }
    }
}