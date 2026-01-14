using Newtonsoft.Json;
using SellGold.Contracts.DTOs.Prices.Responses;

namespace SellGold.GraphQL.Prices.Responses
{
    public class PriceByIdListWrapper
    {
        [JsonProperty("allPricesByIdGraphQL")]
        public List<PriceResponse> AllPricesByIdGraphQL { get; set; } = new();
    }
}
