using SellGold.Products.Application.Contracts.DTOs.Responses;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SellGold.Products.Application.Contracts.DTOs.Messaging
{
    public class ProductMessage
    {
        [JsonPropertyName("productId")]
        public Guid ProductId { get; set; }

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
        public required List<ProductBarcodeMessage> Barcodes { get; set; }

    }
}
