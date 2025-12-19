using Newtonsoft.Json;
using SellGold.Contracts.DTOs.Customers.Responses;
using SellGold.Contracts.DTOs.Products.Responses;

namespace SellGold.GraphQL.Customers.Responses
{
    public class CustomerListWrapper
    {
        [JsonProperty("allCustomersGraphQL")]
        public List<CustomerResponse> AllCustomersGraphQL { get; set; } = new();
    }
}
