using Newtonsoft.Json;
using SellGold.Contracts.DTOs.Payments.Responses;

namespace SellGold.GraphQL.Payments.Responses
{
    public class PaymentCpfWrapper
    {
        [JsonProperty("customerGraphQLByCpf")]
        public CustomerResponse CustomerGraphQLByCpf { get; set; } = new();
    }
}
