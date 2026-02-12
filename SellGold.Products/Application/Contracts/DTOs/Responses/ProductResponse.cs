using System.Text.Json.Serialization;

namespace SellGold.Products.Application.Contracts.DTOs.Responses
{
    public class ProductResponse
    {
        [JsonPropertyName("productId")]
        public Guid ProductId { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("barcodes")]
        public List<ProductBarcodeResponse> Barcodes { get; set; } = new();

        [JsonPropertyName("success")]
        public bool Success { get; set; } = true;

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
