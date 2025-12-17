using Newtonsoft.Json;
using SellGold.Contracts.DTOs.Suppliers.Responses;

namespace SellGold.GraphQL.Suppliers.Responses
{
    public class SupplierListWrapper
    {
        [JsonProperty("allSuppliersGraphQL")]
        public List<SupplierResponse> AllSuppliersGraphQL { get; set; } = new();
    }
}
