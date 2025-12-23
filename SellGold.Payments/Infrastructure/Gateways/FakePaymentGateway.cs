using SellGold.Payments.Domain.Aggregates;
using SellGold.Payments.Domain.Interfaces;
using SellGold.Payments.Domain.ValueObjects;

namespace SellGold.Payments.Infrastructure.Gateways
{
    public class FakePaymentGateway : IPaymentGateway
    {
        public Task<bool> AuthorizeAsync(Payment payment, PaymentMethod method)
        {
            // Simulate a successful authorization for testing purposes
            return Task.FromResult(true);
        }
    }
}
