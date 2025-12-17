namespace SellGold.GraphQL.Products.Queries
{
    public static class ListProductGraphQLQuery
    {
        public const string GetProducts = @"
        query {
            allProductsGraphQL {
            productId
            name
            description
            isActive
            createdAt
            updatedAt
            barcodes {
                barcodeId
                barcode
                type
             }
            }
        }";
    }
}
