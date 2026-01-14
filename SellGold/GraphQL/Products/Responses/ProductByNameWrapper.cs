using Newtonsoft.Json;
using SellGold.Contracts.DTOs.Products.Responses;

namespace SellGold.GraphQL.Products.Responses
{
    public class ProductByNameWrapper
    {
        [JsonProperty("productsGraphQLByName")]
        public List<ProductResponse>? ProductsGraphQLByName { get; set; }
    }
}
