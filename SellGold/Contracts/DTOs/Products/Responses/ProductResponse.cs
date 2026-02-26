using System.Text.Json.Serialization;

namespace SellGold.Contracts.DTOs.Products.Responses
{
    public class ProductResponse
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
        public required List<ProductBarcodeResponse> Barcodes { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
        public string Barcode => Barcodes?.FirstOrDefault()?.Barcode ?? string.Empty;
        public string BarcodeType => Barcodes?.FirstOrDefault()?.BarcodeType ?? string.Empty;
        public string Status => IsActive ? "Ativo" : "Desativo";

        [JsonPropertyName("priceId")]
        public Guid PriceId { get; set; }

        [JsonPropertyName("basePriceAmount")]
        public double BasePriceAmount { get; set; }

        [JsonPropertyName("basePriceCurrency")]
        public string BasePriceCurrency { get; set; } = string.Empty;


    }
}
