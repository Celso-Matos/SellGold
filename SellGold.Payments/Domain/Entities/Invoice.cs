using SellGold.Payments.Domain.Enums;
using SellGold.Payments.Domain.ValueObjects;

namespace SellGold.Payments.Domain.Entities
{
    public class Invoice
    {
        public Guid InvoiceId { get; private set; }
        public Guid PaymentId { get; private set; }
        public Money InvoiceMoney { get; private set; }
        public DateTime IssuedAt { get; private set; }
        public string Number { get; private set; }
        public InvoiceStatus Status { get; private set; }

        public Invoice() { 
        
            InvoiceMoney = new Money(0, "");
            Number = string.Empty;

        } // Para EF Core

        public Invoice(Guid paymentId, Money invoiceMoney, string number)
        {
            InvoiceId = Guid.NewGuid();
            PaymentId = paymentId;
            InvoiceMoney = invoiceMoney ?? throw new ArgumentNullException(nameof(invoiceMoney));
            Number = number ?? throw new ArgumentNullException(nameof(number));
            IssuedAt = DateTime.UtcNow;
            Status = InvoiceStatus.Issued;
        }

        public void MarkAsPaid()
        {
            Status = InvoiceStatus.Paid;
        }

        public void Cancel()
        {
            Status = InvoiceStatus.Canceled;
        }

    }
}
