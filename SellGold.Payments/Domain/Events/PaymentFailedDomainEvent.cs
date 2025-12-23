namespace SellGold.Payments.Domain.Events
{
    public record PaymentFailedDomainEvent(

            Guid PaymentId,
            Guid OrderId,
            string Reason

        );
}
