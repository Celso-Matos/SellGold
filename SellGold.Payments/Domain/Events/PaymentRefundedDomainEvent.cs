using SellGold.Payments.Domain.ValueObjects;

namespace SellGold.Payments.Domain.Events
{
    public record PaymentRefundedDomainEvent(

            Guid PaymentId,
            Guid OrderId,
            Money Amount

        );
}
