using SellGold.Prices.Domain.Entities;
using System.Text.Json.Serialization;

namespace SellGold.Prices.Application.Contracts.DTOs.Responses
{
    public class PriceProductResponse
    {
        [JsonPropertyName("priceProductId")]
        public Guid PriceProductId { get; set; }

        [JsonPropertyName("productId")]
        public Guid ProductId { get; set; }

        [JsonPropertyName("priceId")]
        public Guid PriceId { get; set; }

        [JsonPropertyName("price")]
        public Price? Price { get; set; }

        [JsonPropertyName("effectiveDate")]
        public DateTime EffectiveDate { get; set; }

        [JsonPropertyName("expirationDate")]
        public DateTime? ExpirationDate { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}
