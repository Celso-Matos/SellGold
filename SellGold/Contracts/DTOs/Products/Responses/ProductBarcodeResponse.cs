using System.Text.Json.Serialization;

namespace SellGold.Contracts.DTOs.Products.Responses
{
    public class ProductBarcodeResponse
    {
        [JsonPropertyName("barcodeId")]
        public Guid BarcodeId { get; set; }

        [JsonPropertyName("barcode")]
        public required string Barcode { get; set; }

        [JsonPropertyName("type")]
        public required string Type { get; set; }
    }
}
