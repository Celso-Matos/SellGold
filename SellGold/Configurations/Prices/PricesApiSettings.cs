namespace SellGold.Configurations.Prices
{
    public class PricesApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;

        public EndpointsSettings Endpoints { get; set; } = new();
    }

    public class EndpointsSettings
    {
        public string AddPrice { get; set; } = "";
        public string GetPrices { get; set; } = "";
        public string PriceGraphQL { get; set; } = "";
    }
}
