using SellGold.Payments.Domain.Enums;
using SellGold.Payments.Domain.ValueObjects;

namespace SellGold.Payments.Domain.Entities
{
    public class Payment
    {
        public Guid PaymentId { get; private set; }
        public Money Amount { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public PaymentStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public Invoice Invoice { get; private set; }

        private Payment() { 
        
            Amount = new Money(0, "");
            PaymentMethod = new();
            Invoice = new();

        } // Para EF Core

        public Payment(Money amount, PaymentMethod paymentMethod, Invoice invoice)
        {
            PaymentId = Guid.NewGuid();
            Amount = amount ?? throw new ArgumentNullException(nameof(amount));
            PaymentMethod = paymentMethod ?? throw new ArgumentNullException(nameof(paymentMethod));
            Invoice = invoice ?? throw new ArgumentNullException(nameof(invoice));
            Status = PaymentStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public void Authorize()
        {
            if (!PaymentMethod.SupportsAuthorization)
                throw new InvalidOperationException("Método não suporta autorização.");
            Status = PaymentStatus.Authorized;
        }

        public void Capture()
        {
            if (!PaymentMethod.SupportsCapture)
                throw new InvalidOperationException("Método não suporta captura.");
            Status = PaymentStatus.Captured;
            CompletedAt = DateTime.UtcNow;
        }

        public void Refund(decimal amount)
        {
            if (!PaymentMethod.SupportsPartialRefund && amount < Amount.Value)
                throw new InvalidOperationException("Método não suporta reembolso parcial.");
            Status = PaymentStatus.Refunded;
            CompletedAt = DateTime.UtcNow;
        }

    }
}
