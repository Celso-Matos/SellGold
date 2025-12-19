namespace SellGold.Configurations.Orders
{
    public class OrdersApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;

        public EndpointsSettings Endpoints { get; set; } = new();
    }

    public class EndpointsSettings
    {
        public string AddOrder { get; set; } = "";
        public string GetOrdersGraphQL { get; set; } = "";
    }
}
