using SellGold.Payments.Domain.Entities;
using SellGold.Payments.Domain.Enums;
using SellGold.Payments.Domain.Events;
using SellGold.Payments.Domain.Exceptions;
using SellGold.Payments.Domain.ValueObjects;

namespace SellGold.Payments.Domain.Aggregates
{
    // Aggregate Root com Cache Pattern
    public class Payment
    {
        public Guid PaymentId { get; private set; }
        public Guid OrderId { get; private set; }
        public Money Amount { get; private set; }
        public PaymentStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }

        private readonly List<PaymentTransaction> _transactions = new();
        public IReadOnlyCollection<PaymentTransaction> Transactions => _transactions;

        private readonly List<object> _domainEvents;
        public IReadOnlyCollection<object> DomainEvents => _domainEvents;

        protected Payment() 
        {
            PaymentId = Guid.NewGuid();          
            OrderId = Guid.Empty;                
            Amount = null!;                 
            Status = PaymentStatus.Pending;
            PaymentMethod = null!;
            CreatedAt = DateTime.UtcNow;         

            _domainEvents = new List<object>(); 
        }

        public Payment(Guid orderId, Money amount, PaymentMethod paymentMethod)
        {
            if (amount.IsZero())
                throw new DomainException("Payment amount cannot be zero.");

            PaymentId = Guid.NewGuid();
            OrderId = orderId;
            Amount = amount;
            Status = PaymentStatus.Pending;
            PaymentMethod = paymentMethod;
            CreatedAt = DateTime.UtcNow;

            _domainEvents = new List<object>();
        }

        public void Authorize()
        {
            if (Status != PaymentStatus.Pending)
                throw new DomainException("Payment cannot be authorized.");

            Status = PaymentStatus.Authorized;
            _domainEvents.Add(new PaymentAuthorizedDomainEvent(PaymentId, OrderId, Amount));
        }

        public void Fail(string reason)
        {
            Status = PaymentStatus.Failed;
            _domainEvents.Add(new PaymentFailedDomainEvent(PaymentId, OrderId, reason));
        }

        public void Refund()
        {
            if (Status != PaymentStatus.Paid)
                throw new DomainException("Only paid payments can be refunded.");

            Status = PaymentStatus.Refunded;
            _domainEvents.Add(new PaymentRefundedDomainEvent(PaymentId, OrderId, Amount));
        }

        public void ClearEvents() => _domainEvents.Clear();
    }
}