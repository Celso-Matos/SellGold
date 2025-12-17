using SellGold.GraphQL.Stock.Queries;

namespace SellGold.GraphQL.Stock.Queries
{
    public static class ListStockGraphQLQuery
    {
        public const string GetStock = @"
        query {
            allStocksGraphQL {
                stockProductId
                ProductId
                currentQuantity          
                createdAt
                updatedAt
                stockMovement {
                  stockMovementId
                  stockProductId
                  dateMovement
                  amountMovement
                  movementType
                  observation
                  createdAt
                  updatedAt
                }
                stockLocation {
                  stockLocationId
                  stockProductId
                  addressId
                  stockLocationName                  
                  createdAt
                  updatedAt
                  addresses {
                        addressId
                        street
                        number
                        complement
                        district
                        city
                        state
                        zipCode
                        country
                    }
                }                
            }
        }";
    }
}
