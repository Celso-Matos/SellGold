using Newtonsoft.Json;
using SellGold.Contracts.DTOs.Stock.Responses;

namespace SellGold.GraphQL.Stock.Responses
{
    public class StockListWrapper
    {
        [JsonProperty("allStockGraphQL")]
        public List<StockResponse> AllStockGraphQL { get; set; } = new();
    }
}
