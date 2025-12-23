using SellGold.Payments.Domain.Aggregates;
using SellGold.Payments.Domain.ValueObjects;

namespace SellGold.Payments.Domain.Interfaces
{
    public interface IPaymentGateway
    {
        Task<bool> AuthorizeAsync(Payment payment, PaymentMethod method);
    }
}
