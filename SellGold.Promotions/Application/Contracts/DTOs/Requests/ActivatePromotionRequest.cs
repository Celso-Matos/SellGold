namespace SellGold.Promotions.Application.Contracts.DTOs.Requests
{
    public sealed class ActivatePromotionRequest
    {
        public Guid PromotionId { get; init; }
        public DateTime ActivatedAt { get; init; }
    }
}
