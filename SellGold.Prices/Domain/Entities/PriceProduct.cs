using SellGold.Prices.Domain.Exceptions;

namespace SellGold.Prices.Domain.Entities
{
    public class PriceProduct
    {
        
        protected PriceProduct() 
        { 
            
        
        }

        public PriceProduct(Guid productId, Guid priceId, DateTime effectiveDate, DateTime? expirationDate, bool isActive)
        {
            PriceProductId = Guid.NewGuid();
            ProductId = productId;
            PriceId = priceId;
            EffectiveDate = effectiveDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid PriceProductId { get; set; }
        public Guid ProductId { get; set; }
        public Guid PriceId { get; set; }
        public Price? Price { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public void Activate()
        {
            IsActive = true;
            Touch();
        }

        public void Deactivate()
        {
            IsActive = false;
            Touch();
        }

        private void Touch()
        {
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
