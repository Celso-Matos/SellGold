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
                BasePriceAmount = model.NewBasePriceAmount,
                BasePriceCurrency = model.NewBasePriceCurrency,
                Discounts = model.NewDiscounts?.ToList() ?? new List<PriceDiscountRequest>(),
                Policies = model.NewPolicies?.ToList() ?? new List<PricePolicyRequest>(),
                Taxes = model.NewTaxes?.ToList() ?? new List<PriceTaxRequest>()
            };
    }
}
