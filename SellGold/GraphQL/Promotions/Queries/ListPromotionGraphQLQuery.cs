
namespace SellGold.GraphQL.Promotions.Queries
{
    public static class ListPromotionGraphQLQuery
    {
        public const string GetPromotions = @"
            query {
                allPromotionsGraphQL {
                    promotionId
                    name
                    startDate
                    endDate
                    description
                    discountPercentage
                    isActive
                    createdAt
                    updatedAt
                }
            }";
    }
}
