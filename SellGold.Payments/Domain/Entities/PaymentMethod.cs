using SellGold.Payments.Domain.Enums;

namespace SellGold.Payments.Domain.Entities
{
    public class PaymentMethod
    {
        public Guid PaymentMethodId { get; private set; }
        public string PaymentMethodCode { get; private set; }
        public PaymentMethodType PaymentMethodType { get; private set; }
        public bool SupportsAuthorization { get; private set; }
        public bool SupportsCapture { get; private set; }
        public bool SupportsPartialRefund { get; private set; }
        public bool IsActive { get; private set; }

        public PaymentMethod() {

            PaymentMethodCode = string.Empty;

        } // Para EF Core

        public PaymentMethod(
            string paymentMethodCode,
            PaymentMethodType paymentMethodType,
            bool supportsAuthorization,
            bool supportsCapture,
            bool supportsPartialRefund)
        {
            PaymentMethodId = Guid.NewGuid();
            PaymentMethodCode = paymentMethodCode ?? throw new ArgumentNullException(nameof(paymentMethodCode));
            PaymentMethodType = paymentMethodType;
            SupportsAuthorization = supportsAuthorization;
            SupportsCapture = supportsCapture;
            SupportsPartialRefund = supportsPartialRefund;
            IsActive = true;
        }

        public void Activate() => IsActive = true;
        public void Deactivate() => IsActive = false;

    }
}
