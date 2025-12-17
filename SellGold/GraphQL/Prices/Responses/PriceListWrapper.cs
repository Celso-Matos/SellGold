using Newtonsoft.Json;
using SellGold.Contracts.DTOs.Prices.Responses;

namespace SellGold.GraphQL.Prices.Responses
{
    public class PriceListWrapper
    {
        [JsonProperty("allPricesGraphQL")]
        public List<PriceResponse> AllPricesGraphQL { get; set; } = new();
    }
}
