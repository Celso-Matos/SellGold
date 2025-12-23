using SellGold.Payments.Domain.Enums;
using SellGold.Payments.Domain.ValueObjects;
using System.Dynamic;

namespace SellGold.Payments.Domain.Entities
{
    public class PaymentTransaction
    {
        public Guid PaymentTransactionId { get; private set; }
        public PaymentType Type { get; private set; }
        public PaymentStatus Status { get; private set; }
        public DateTime OccurredAt { get; private set; }
        public CardInfo CardInfo { get; private set; }


        protected PaymentTransaction() 
        { 
            CardInfo = null!;
        }

        public PaymentTransaction(PaymentType type, PaymentStatus status, CardInfo cardInfo)
        {
            PaymentTransactionId = Guid.NewGuid();
            Type = type;
            Status = status;
            OccurredAt = DateTime.UtcNow;
            CardInfo = cardInfo;

        }
    }
}
