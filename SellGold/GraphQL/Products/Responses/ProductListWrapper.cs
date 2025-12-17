using Newtonsoft.Json;
using SellGold.Contracts.DTOs.Products.Responses;

namespace SellGold.GraphQL.Products.Responses
{
    public class ProductListWrapper
    {
        [JsonProperty("allProductsGraphQL")]
        public List<ProductResponse> AllProductsGraphQL { get; set; } = new();

    }
}

