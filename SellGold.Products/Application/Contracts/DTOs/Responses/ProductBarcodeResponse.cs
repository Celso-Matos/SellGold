using System.Text.Json.Serialization;

namespace SellGold.Products.Application.Contracts.DTOs.Responses
{
    public class ProductBarcodeResponse
    {
        [JsonPropertyName("barcodeId")]
        public Guid BarcodeId { get; init; }

        [JsonPropertyName("barcode")]
        public required string Barcode { get; set; }

        [JsonPropertyName("type")]
        public required string Type { get; set; }
    }
}
