
namespace SellGold.GraphQL.Prices.Queries
{
    public static class ListPriceByIdGraphQLQuery
    {
        public const string GetPricesById = @"
        query($priceId: Guid) {
            allPricesByIdGraphQL($priceId: Guid) {
                priceId
                basePriceAmount
                basePriceCurrency
                discounts {
                  priceDiscountId
                  type
                  value
                  startDate
                  endDate
                  priceId
                  createdAt
                  updatedAt
                  isActive
                }
                policies {
                  pricePolicyId
                  strategy
                  rules
                  createdAt
                  updatedAt
                  isActive
                }
                taxes {
                  priceTaxId
                  name
                  rate
                  priceId
                  createdAt
                  updatedAt
                  isActive
                }
                isActive
                createdAt
                updatedAt
            }
        }";
    }
}
