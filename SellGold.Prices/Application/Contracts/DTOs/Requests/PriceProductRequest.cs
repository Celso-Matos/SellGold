using SellGold.Prices.Domain.Entities;

namespace SellGold.Prices.Application.Contracts.DTOs.Requests
{
    public class PriceProductRequest
    {
        public Guid ProductId { get; set; }
        public Guid PriceId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
