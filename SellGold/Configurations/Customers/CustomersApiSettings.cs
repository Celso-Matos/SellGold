
namespace SellGold.Configurations.Customers
{
    public class CustomersApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;

        public EndpointsSettings Endpoints { get; set; } = new();
    }

    public class EndpointsSettings
    {
        public string AddCustomer { get; set; } = "";
        public string GetCustomersGraphQL { get; set; } = "";
    }
}
