using SellGold.Configurations.Products;

namespace SellGold.Configurations.Suppliers
{
    public class SuppliersApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;

        public EndpointsSettings Endpoints { get; set; } = new();
    }

    public class EndpointsSettings
    {
        public string AddSupplier { get; set; } = "";        
        public string SupplierGraphQL { get; set; } = "";
    }
}
