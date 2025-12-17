
namespace SellGold.Stock.Domain.Entities
{
    public class StockLocation
    {
        public Guid StockLocationId { get; set; }
        public Guid StockProductId { get; set; }
        public Guid AddressId { get; set; }
        public required string StockLocationName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public List<Address> Addresses { get; set; } = new();

    }
}
