
namespace SellGold.Products.Domain.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public required List<ProductBarcode> Barcode { get; set; } = new();

    }
}
