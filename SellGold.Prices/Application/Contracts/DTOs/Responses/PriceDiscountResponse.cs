using System.Text.Json.Serialization;

namespace SellGold.Prices.Application.Contracts.DTOs.Responses
{
    public class PriceDiscountResponse
    {
        [JsonPropertyName("priceDiscountId")]
        public required Guid PriceDiscountId { get; set; }

        [JsonPropertyName("type")]
        public required int Type { get; set; }

        [JsonPropertyName("value")]
        public required decimal Value { get; set; }

        [JsonPropertyName("startDate")]
        public required DateTime StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public required DateTime EndDate { get; set; }

        [JsonPropertyName("priceId")]
        public required Guid PriceId { get; set; }
    }
}
