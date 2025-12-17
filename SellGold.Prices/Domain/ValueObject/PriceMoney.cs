using Microsoft.EntityFrameworkCore;

namespace SellGold.Prices.Domain.ValueObject
{
    [Owned] // EF Core trata como Value Object
    public class PriceMoney
    {
        public required decimal Amount { get; set; }
        public required string Currency { get; set; } // Ex: "BRL", "USD"

    }
}
