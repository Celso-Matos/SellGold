namespace SellGold.Stock.Domain.Entities
{
    public class StockMovement
    {
        public Guid StockMovementId { get; set; }
        public required Guid StockProductId { get; set; }
        public required DateTime DateMovement { get; set; }
        public required int AmountMovement { get; set; }        
        public required int MovementType { get; set; }
        public string? Observation { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
