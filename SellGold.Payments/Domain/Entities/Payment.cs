using SellGold.Payments.Domain.Enums;
using SellGold.Payments.Domain.ValueObjects;
using static MongoDB.Driver.WriteConcern;

namespace SellGold.Payments.Domain.Entities
{
    public class Payment
    {
        public Guid PaymentId { get; private set; }
        public Money PaymentMoney { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public PaymentStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public Invoice Invoice { get; private set; }

        private Payment() { 
        
            PaymentMoney = new Money(0, "");
            PaymentMethod = new();
            Invoice = new();

        } // Para EF Core

        public Payment(Money paymentMoney, PaymentMethod paymentMethod, Invoice invoice)
        {
            PaymentId = Guid.NewGuid();
            PaymentMoney = paymentMoney ?? throw new ArgumentNullException(nameof(paymentMoney));
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

        public void Refund(Money refundAmount)
        {
            if (refundAmount == null) throw new ArgumentNullException(nameof(refundAmount));
            if (refundAmount.Currency != PaymentMoney.Currency)
                throw new InvalidOperationException("Moeda do reembolso deve ser igual à do pagamento.");

            // Parcial vs total
            bool isPartial = refundAmount.Amount < PaymentMoney.Amount;

            if (isPartial && !PaymentMethod.SupportsPartialRefund)
                throw new InvalidOperationException("Método não suporta reembolso parcial.");

            if (refundAmount.Amount > PaymentMoney.Amount)
                throw new InvalidOperationException("Valor de reembolso não pode exceder o pagamento.");

            Status = PaymentStatus.Refunded;
            CompletedAt = DateTime.UtcNow;
        }

    }
}
