namespace SellGold.Promotions.Domain.Entities
{
    public class CashbackAccount
    {
        // Required fields
        public Guid CashbackAccountId { get; private set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; } // Required
        public decimal Balance { get; private set; } = 0;

        // Domain methods
        public void AccumulateCashback(decimal purchaseValue)
        {
            // Example: 5% cashback
            Balance += purchaseValue * 0.05m;
        }

        public bool RedeemCashback(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
