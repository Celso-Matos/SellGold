
namespace SellGold.GraphQL.Prices.Queries
{
    public static class ListPriceProductGraphQLQuery
    {
        public const string GetPriceByProduct = @"{
                query($productId: Guid) {
                    allPricesProductGraphQL($productId: Guid) {
                        PriceId
                        EffectiveDate
                        ExpirationDate
                        IsActive
                        CreatedAt
                        UpdatedAt

                }
            }                
        }";
    }
}
