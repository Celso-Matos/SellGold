using System.Text.Json.Serialization;

namespace SellGold.Prices.Application.Contracts.DTOs.Responses
{
    public class PricePolicyResponse
    {
        [JsonPropertyName("pricePolicyId")]
        public required Guid PricePolicyId { get; set; }

        [JsonPropertyName("strategy")]
        public required int Strategy { get; set; }

        [JsonPropertyName("rules")]
        public required string Rules { get; set; }
    }
}
