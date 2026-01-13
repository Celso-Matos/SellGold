namespace SellGold.GraphQL.Products.Queries
{
    public static class ListProductBarcodeGraphQLQuery
    {
        public const string GetProductByBarcode = @"
            query($barcode: String!) {
                productByBarcodeGraphQL(barcode: $barcode) {
                    productId
                    name
                    description
                    isActive
                    createdAt
                    updatedAt
                    barcodes {
                        barcodeId
                        barcode
                        barcodeType
                     }
            }
        }";
    }
}
