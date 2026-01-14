using Newtonsoft.Json;
using SellGold.Contracts.DTOs.Prices.Responses;

namespace SellGold.GraphQL.Prices.Responses
{
    public class PriceProductListWrapper
    {
        [JsonProperty("allPricesProductGraphQL")]
        public List<PriceResponse> AllPricesProductGraphQL { get; set; } = new();
    }
}
