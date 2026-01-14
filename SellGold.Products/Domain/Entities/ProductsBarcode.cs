
namespace SellGold.Products.Domain.Entities
{
    public class ProductBarcode
    {

        protected ProductBarcode()
        {
            Barcode = null!;
            BarcodeType = null!;
        } // EF Core

        public ProductBarcode(string barcode, string barcodeType)
        {
            BarcodeId = Guid.NewGuid();
            Barcode = barcode;
            BarcodeType = barcodeType;
        }
        public Guid BarcodeId { get; set; }
        public Guid ProductId { get; set; }
        public string Barcode { get; set; }
        public string BarcodeType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Product Product { get; set; } = null!;
    }
}
