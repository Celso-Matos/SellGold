using System.Text.Json.Serialization;

namespace SellGold.Stock.Application.Contracts.DTOs.Responses
{
    public class StockMovementResponse
    {
        [JsonPropertyName("stockMovementId")]
        public Guid StockMovementId { get; init; }

        [JsonPropertyName("stockProductId")]
        public required Guid StockProductId { get; set; }

        [JsonPropertyName("dateMovement")]
        public required DateTime DateMovement { get; set; }

        [JsonPropertyName("amountMovement")]
        public required int AmountMovement { get; set; }

        [JsonPropertyName("movementType")]
        public int MovementType { get; set; }

        [JsonPropertyName("observation")]
        public string? Observation { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; init; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; init; }
    }
}