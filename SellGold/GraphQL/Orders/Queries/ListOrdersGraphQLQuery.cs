namespace SellGold.GraphQL.Orders.Queries
{
    public static class ListOrdersGraphQLQuery
    {
        public const string GetOrders = @"
        query {
            allOrdersGraphQL {
                orderId
                customerId
                date
                status
                totalValue
                items {
                    productId
                    quantity
                    unitPrice
                    total
                        }
                createdAt
                updatedAt
              }
            }
        ";

    }
}
