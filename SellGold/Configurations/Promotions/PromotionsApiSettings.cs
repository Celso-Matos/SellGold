namespace SellGold.Configurations.Promotions
{
    public class PromotionsApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;

        public EndpointsSettings Endpoints { get; set; } = new();
    }

    public class EndpointsSettings
    {
        public string AddPromotion { get; set; } = "";
        public string GetPromotionsGraphQL { get; set; } = "";
    }
}
