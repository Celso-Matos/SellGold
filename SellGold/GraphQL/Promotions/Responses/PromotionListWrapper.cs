using Newtonsoft.Json;
using SellGold.Contracts.DTOs.Promotions.Responses;

namespace SellGold.GraphQL.Promotions.Responses
{
    public class PromotionListWrapper
    {
        [JsonProperty("allPromotionsGraphQL")]
        public List<PromotionResponse> AllPromotionsGraphQL { get; set; } = new ();
    }
}
