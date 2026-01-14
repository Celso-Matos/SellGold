using Newtonsoft.Json;
using SellGold.Contracts.DTOs.Products.Responses;

namespace SellGold.GraphQL.Products.Responses
{
    public class ProductByBarcodeWrapper
    {
        [JsonProperty("productGraphQLByBarcode")]
        public ProductResponse? ProductGraphQLByBarcode { get; set; }
    }
}
