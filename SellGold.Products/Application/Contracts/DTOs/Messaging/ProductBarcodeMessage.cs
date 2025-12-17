using System.Text.Json.Serialization;

namespace SellGold.Products.Application.Contracts.DTOs.Messaging
{
    public class ProductBarcodeMessage
    {
        [JsonPropertyName("barcodeId")]
        public Guid BarcodeId { get; set; }

        [JsonPropertyName("barcode")]
        public required string Barcode { get; set; }

        [JsonPropertyName("type")]
        public required string Type { get; set; }
    }
}
