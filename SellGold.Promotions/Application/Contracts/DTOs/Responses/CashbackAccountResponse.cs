namespace SellGold.Promotions.Application.Contracts.DTOs.Responses
{
    public sealed class CashbackAccountResponse
    {
        public Guid CashbackAccountId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
