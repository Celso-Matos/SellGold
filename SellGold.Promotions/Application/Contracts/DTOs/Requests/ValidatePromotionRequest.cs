namespace SellGold.Promotions.Application.Contracts.DTOs.Requests
{
    public sealed class ValidatePromotionRequest
    {
        public Guid PromotionId { get; init; }
        public Guid CustomerId { get; init; }

        public decimal OrderTotalValue { get; init; }

        public IReadOnlyCollection<Guid> ProductIds { get; init; }
            = Array.Empty<Guid>();
    }
}
