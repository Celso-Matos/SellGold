using SellGold.Contracts.DTOs.Promotions.Requests;
using SellGold.PageModels.Promotions;

namespace SellGold.Mappings.Promotions
{
    public static class PromotionMapping
    {
        public static CreatePromotionRequest ToRequest(PromotionPageModel model) =>
            new CreatePromotionRequest
            {
                Name = model.Name,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                DiscountPercentage = model.DiscountPercentage,
                Description = model.Description
            };

    }
}
