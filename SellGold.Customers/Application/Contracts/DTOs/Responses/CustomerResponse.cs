using SellGold.Customers.Application.Contracts.DTOs.Requests;
using System.Text.Json.Serialization;

namespace SellGold.Customers.Application.Contracts.DTOs.Responses
{
    public class CustomerResponse
    {
        [JsonPropertyName("customerId")]
        public Guid CustomerId { get; set; }

        // Dados principais
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("document")]
        public string Document { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        // Status
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        // Endereços
        [JsonPropertyName("addresses")]
        public List<AddressResponse> Addresses { get; set; } = new();

        // Metadados
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("success", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Success { get; set; } = true;

        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string? Message { get; set; }


    }
}
