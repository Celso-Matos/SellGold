namespace SellGold.Stock.Domain.Entities
{
    public class StockProduct
    {
        public Guid StockProductId { get; set; }
        public required Guid ProductId { get; set; }
        public required int CurrentQuantity { get; set; }
        public List<StockMovement> StockMovement { get; set; } = new();
        public List<StockLocation> StockLocation { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
