using Newtonsoft.Json;
using SellGold.Contracts.DTOs.Prices.Responses;

namespace SellGold.GraphQL.Prices.Responses
{
    public class PriceProductListWrapper
    {
        [JsonProperty("allPricesProductsByIdGraphQL")]
        public List<PriceProductsResponse>? AllPricesProductsByIdGraphQL { get; set; } = new();
    }
}
