using System.Text.Json.Serialization;

namespace SellGold.Contracts.DTOs.Prices.Responses
{
    public class PriceProductsResponse
    {
        [JsonPropertyName("priceProductId")]
        public Guid PriceProductId { get; set; }

        [JsonPropertyName("productId")]
        public Guid ProductId { get; set; }

        [JsonPropertyName("priceId")]
        public Guid PriceId { get; set; }        

        [JsonPropertyName("effectiveDate")]
        public DateTime EffectiveDate { get; set; }

        [JsonPropertyName("expirationDate")]
        public DateTime? ExpirationDate { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("success", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Success { get; set; }

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string? Message { get; set; }
    }
}
