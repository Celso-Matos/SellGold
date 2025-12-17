
namespace SellGold.GraphQL.Prices.Queries
{
    public static class ListPriceGraphQLQuery
    {
        public const string GetPrices = @"
        query {
            allPricesGraphQL {
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
