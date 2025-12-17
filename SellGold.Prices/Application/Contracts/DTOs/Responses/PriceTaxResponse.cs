using System.Text.Json.Serialization;

namespace SellGold.Prices.Application.Contracts.DTOs.Responses
{
    public class PriceTaxResponse
    {
        [JsonPropertyName("priceTaxId")]
        public required Guid PriceTaxId { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("rate")]
        public required decimal Rate { get; set; }

        [JsonPropertyName("priceId")]
        public required Guid PriceId { get; set; }
    }
}
