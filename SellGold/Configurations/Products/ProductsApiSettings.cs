namespace SellGold.Configurations.Products
{
    public class ProductsApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;

        public EndpointsSettings Endpoints { get; set; } = new();


    }

    public class EndpointsSettings
    {
        public string AddProduct { get; set; } = "";
        public string SendProductProduceMessage { get; set; } = "";
        public string GetProducts { get; set; } = "";
        public string ProductGraphQL { get; set; } = "";
    }

}
