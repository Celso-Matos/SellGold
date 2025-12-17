
namespace SellGold.Products.Domain.Entities
{
    public class ProductBarcode
    {
        public Guid BarcodeId { get; set; }
        public Guid ProductId { get; set; }
        public required string Barcode { get; set; }
        public required string Type { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Product Product { get; set; } = null!;
    }
}
