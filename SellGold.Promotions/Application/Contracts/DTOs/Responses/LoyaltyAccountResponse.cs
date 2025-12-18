namespace SellGold.Promotions.Application.Contracts.DTOs.Responses
{
    public class LoyaltyAccountResponse
    {
        public Guid LoyaltyAccountId { get; set; }
        public Guid CustomerId { get; set; }
        public int Points { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
