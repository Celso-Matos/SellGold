using Newtonsoft.Json;
using SellGold.Contracts.DTOs.Orders.Responses;

namespace SellGold.GraphQL.Orders.Responses
{
    public class OrderListWrapper
    {
        [JsonProperty("allOrdersGraphQL")]
        public List<OrderResponse> AllOrdersGraphQL { get; set; } = new();
    }
}
