using Newtonsoft.Json;
using SellGold.Contracts.DTOs.Products.Responses;

namespace SellGold.GraphQL.Products.Responses
{
    public class ProductByBarcodeWrapper
    {
        [JsonProperty("productByBarcodeGraphQL")]
        public ProductResponse? ProductByBarcodeGraphQL { get; set; }
    }
}
