using SellGold.Payments.Domain.ValueObjects;

namespace SellGold.Payments.Domain.Events
{
    public record PaymentAuthorizedDomainEvent(

            Guid PaymentId,
            Guid OrderId,
            Money Amount

        );
}
