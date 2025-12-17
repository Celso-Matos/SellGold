namespace SellGold.Promotions.Domain.Entities
{
    public class LoyaltyAccount
    {
        // Required fields
        public Guid LoyaltyAccountId { get; private set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; } // Required
        public int Points { get; private set; } = 0;

        // Domain methods
        public void AccumulatePoints(decimal purchaseValue)
        {
            // Example: 1 point for each $10 spent
            Points += (int)(purchaseValue / 10);
        }

        public bool RedeemPoints(int points)
        {
            if (points <= Points)
            {
                Points -= points;
                return true;
            }
            return false;
        }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
