namespace SellGold.GraphQL.Products.Queries
{
    public static class ListProductNameGraphQLQuery
    {
        public const string GetProductsByName = @"
            query($name: String!) {
                productsGraphQLByName(name: $name) {
                    productId
                    name
                    description
                    isActive
                    createdAt
                    updatedAt
                    message
                    success
                    barcodes {
                        barcodeId
                        barcode
                        barcodeType
                     }
            }
        }";
    }
}
