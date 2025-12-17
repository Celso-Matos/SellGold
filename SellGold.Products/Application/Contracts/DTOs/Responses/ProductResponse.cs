using System.Text.Json.Serialization;

namespace SellGold.Products.Application.Contracts.DTOs.Responses
{
    public class ProductResponse
    {
        [JsonPropertyName("productId")]
        public Guid ProductId { get; init; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("description")]
        public required string Description { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("barcodes")]
        public required List<ProductBarcodeResponse> Barcodes { get; set; }
    }
}
