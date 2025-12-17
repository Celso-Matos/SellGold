using System.Text.Json.Serialization;

namespace SellGold.Stock.Application.Contracts.DTOs.Responses
{
    public class StockProductResponse
    {
        [JsonPropertyName("stockProductId")]
        public Guid StockProductId { get; init; }

        [JsonPropertyName("productId")]
        public required Guid ProductId { get; set; }

        [JsonPropertyName("currentQuantity")]
        public required int CurrentQuantity { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; init; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; init; }

        [JsonPropertyName("stockMovement")]
        public List<StockMovementResponse> StockMovement { get; set; } = new();

        [JsonPropertyName("stockLocation")]
        public List<StockLocationResponse> StockLocation { get; set; } = new();
    }
}