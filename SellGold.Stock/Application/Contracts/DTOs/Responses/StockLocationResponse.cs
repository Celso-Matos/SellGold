using System.Text.Json.Serialization;

namespace SellGold.Stock.Application.Contracts.DTOs.Responses
{
    public class StockLocationResponse
    {
        [JsonPropertyName("stockLocationId")]
        public Guid StockLocationId { get; init; }

        [JsonPropertyName("stockLocationName")]
        public required string StockLocationName { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; init; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; init; }

        [JsonPropertyName("addresses")]
        public List<AddressResponse> Addresses { get; set; } = new();
    }
}