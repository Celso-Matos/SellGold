
using System.Text.Json.Serialization;

namespace SellGold.Contracts.DTOs.Prices.Responses
{
    public partial class PriceResponse
    {

        [JsonPropertyName("priceId")]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid PriceId { get; set; }

        [JsonPropertyName("basePriceAmount")]
        public double BasePriceAmount { get; set; }

        [JsonPropertyName("basePriceCurrency")]
        public string BasePriceCurrency { get; set; } = string.Empty;

        [JsonPropertyName("discounts")]
        public System.Collections.Generic.ICollection<PriceDiscountResponse> Discounts { get; set; } = new System.Collections.ObjectModel.Collection<PriceDiscountResponse>();

        [JsonPropertyName("policies")]
        public System.Collections.Generic.ICollection<PricePolicyResponse> Policies { get; set; } = new System.Collections.ObjectModel.Collection<PricePolicyResponse>();

        [JsonPropertyName("taxes")]
        public System.Collections.Generic.ICollection<PriceTaxResponse> Taxes { get; set; } = new System.Collections.ObjectModel.Collection<PriceTaxResponse>();

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("createdAt")]
        public System.DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public System.DateTimeOffset? UpdatedAt { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; } = true;

        [JsonPropertyName("message")]
        public string? Message { get; set; }

    }
}
