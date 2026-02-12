
namespace SellGold.GraphQL.Prices.Queries
{
    public static class ListPriceProductsByIdGraphQLQuery
    {
        public const string GetPriceByProduct = @"
            query ($productId: UUID!) {
                allPricesProductsByIdGraphQL(productId: $productId) {
                    priceId
                    effectiveDate
                    expirationDate
                    isActive
                    createdAt
                    updatedAt
                    message
                    success
                }
            }";
    }
}
