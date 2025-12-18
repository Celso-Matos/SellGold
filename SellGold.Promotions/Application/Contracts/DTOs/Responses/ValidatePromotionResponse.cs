namespace SellGold.Promotions.Application.Contracts.DTOs.Responses
{
    public sealed class ValidatePromotionResponse
    {
        public bool IsValid { get; init; }
        public decimal DiscountAmount { get; init; }
        public decimal CashbackAmount { get; init; }
        public int EarnedPoints { get; init; }
        public string? Reason { get; init; }
    }
}
