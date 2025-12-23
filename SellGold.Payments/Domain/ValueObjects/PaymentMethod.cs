using SellGold.Payments.Domain.Enums;

namespace SellGold.Payments.Domain.ValueObjects
{
    public sealed class PaymentMethod
    {
        public PaymentType Type { get; }
        public string Provider { get; }

        public PaymentMethod(PaymentType type, string provider)
        {
            Type = type;
            Provider = provider;
        }
    }
}
