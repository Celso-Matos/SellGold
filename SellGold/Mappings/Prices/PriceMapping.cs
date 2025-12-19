using SellGold.Contracts.DTOs.Prices.Requests;
using SellGold.PageModels.Prices;

namespace SellGold.Mappings.Prices
{
    public static class PriceMapping
    {
        public static CreatePriceRequest ToRequest(PricePageModel model) =>
            new CreatePriceRequest
            {
                PriceId = Guid.NewGuid(),
                BasePriceAmount = model.BasePriceAmount,
                BasePriceCurrency = model.BasePriceCurrency,
                Discounts = model.Discounts?.ToList() ?? new List<PriceDiscountRequest>(),
                Policies = model.Policies?.ToList() ?? new List<PricePolicyRequest>(),
                Taxes = model.Taxes?.ToList() ?? new List<PriceTaxRequest>()
            };
    }
}
