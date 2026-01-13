namespace SellGold.Prices.Domain.Entities
{
    public class PriceProduct
    {
        public Guid PriceProductId { get; set; }
        public Guid ProductId { get; set; }
        public Guid PriceId { get; set; }
        public Price? Price { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
