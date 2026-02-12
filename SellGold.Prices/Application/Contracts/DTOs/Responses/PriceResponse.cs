using System.Text.Json.Serialization;
namespace SellGold.Prices.Application.Contracts.DTOs.Responses
{
    public class PriceResponse
    {
        [JsonPropertyName("priceId")]
        public Guid PriceId { get; set; }        

        [JsonPropertyName("basePriceAmount")]
        public decimal BasePriceAmount { get; set; }

        [JsonPropertyName("basePriceCurrency")]
        public string BasePriceCurrency { get; set; } = string.Empty;

        [JsonPropertyName("priceProducts")]
        public List<PriceProductsResponse> PriceProducts { get; set; } = new();

        [JsonPropertyName("discounts")]
        public List<PriceDiscountResponse> Discounts { get; set; } = new();

        [JsonPropertyName("policies")]
        public List<PricePolicyResponse> Policies { get; set; } = new();

        [JsonPropertyName("taxes")]
        public List<PriceTaxResponse> Taxes { get; set; } = new();

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; } = true;

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
