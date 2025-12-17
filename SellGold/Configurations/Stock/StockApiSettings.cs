namespace SellGold.Configurations.Stock
{
    public class StockApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;

        public EndpointsSettings Endpoints { get; set; } = new();


    }

    public class EndpointsSettings
    {
        public string AddStock { get; set; } = "";
        public string SendStockProduceMessage { get; set; } = "";
        public string GetStock { get; set; } = "";
        public string StockGraphQL { get; set; } = "";
    }

}
