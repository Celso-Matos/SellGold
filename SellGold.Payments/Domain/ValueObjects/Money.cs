namespace SellGold.Payments.Domain.ValueObjects
{
    public class Money
    {
        public decimal Value { get; }
        public string Currency { get; }

        private Money() { 
        
            Currency = string.Empty;

        } // Para EF Core

        public Money(decimal value, string currency)
        {
            if (value < 0) throw new ArgumentException("Valor não pode ser negativo.");
            Value = value;
            Currency = currency ?? throw new ArgumentNullException(nameof(currency));
        }

        public Money Add(Money other)
        {
            EnsureSameCurrency(other);
            return new Money(Value + other.Value, Currency);
        }

        public Money Subtract(Money other)
        {
            EnsureSameCurrency(other);
            return new Money(Value - other.Value, Currency);
        }

        private void EnsureSameCurrency(Money other)
        {
            if (Currency != other.Currency)
                throw new InvalidOperationException("Moedas diferentes não podem ser combinadas.");
        }

        public override string ToString() => $"{Currency} {Value:N2}";

    }
}
