namespace SellGold.Payments.Domain.ValueObjects
{
    public class Money
    {
        public decimal Value { get; }
        public string Currency { get; }

        protected Money()
        {
            Currency = string.Empty;
        }   

        public Money(decimal value, string currency)
        {
            if (value < 0)
                throw new ArgumentException("Money cannot be negative.");

            Value = value;
            Currency = currency;
        }

        public bool IsZero() => Value == 0;

        public override bool Equals(object? obj)
        {
            if (obj is not Money other) return false;
            return Value == other.Value && Currency == other.Currency;
        }

        public override int GetHashCode() => HashCode.Combine(Value, Currency);
    }
}
