using System.Text.Json.Serialization;
namespace SellGold.Prices.Application.Contracts.DTOs.Responses
{
    public class PriceResponse
    {
        [JsonPropertyName("priceId")]
        public required Guid PriceId { get; set; }

        [JsonPropertyName("basePriceAmount")]
        public required decimal BasePriceAmount { get; set; }

        [JsonPropertyName("basePriceCurrency")]
        public required string BasePriceCurrency { get; set; }

        [JsonPropertyName("discounts")]
        public required List<PriceDiscountResponse> Discounts { get; set; }

        [JsonPropertyName("policies")]
        public required List<PricePolicyResponse> Policies { get; set; }

        [JsonPropertyName("taxes")]
        public required List<PriceTaxResponse> Taxes { get; set; }

        [JsonPropertyName("isActive")]
        public required bool IsActive { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}
