namespace SellGold.Promotions.Application.Contracts.DTOs.Requests
{
    public sealed class DeactivatePromotionRequest
    {
        public Guid PromotionId { get; init; }
        public string? Reason { get; init; }
        public DateTime DeactivatedAt { get; init; }
    }
}
