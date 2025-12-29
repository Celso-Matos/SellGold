using Microsoft.EntityFrameworkCore;

namespace SellGold.Payments.Domain.ValueObjects
{
    [Owned] // EF Core trata como Value Object
    public class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        private Money() {

            Currency = string.Empty;

        } // Para EF Core

        public Money(decimal value, string currency)
        {
            if (value < 0) throw new ArgumentException("Valor não pode ser negativo.");
            Amount = value;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public Money Add(Money other)
        {
            EnsureSameCurrency(other);
            return new Money(Amount + other.Amount, Currency);
        }

        public Money Subtract(Money other)
        {
            EnsureSameCurrency(other);
            return new Money(Amount - other.Amount, Currency);
        }

        private void EnsureSameCurrency(Money other)
        {
            if (Currency != other.Currency)
                throw new InvalidOperationException("Moedas diferentes não podem ser combinadas.");
        }

        public override string ToString() => $"{Currency} {Amount:N2}";

    }
}
