using System.Text.Json.Serialization;

namespace SellGold.Suppliers.Application.Contracts.DTOs.Responses
{
    public class SupplierResponse
    {
        [JsonPropertyName("supplierId")]
        public Guid SupplierId { get; init; }

        [JsonPropertyName("corporateName")]
        public required string CorporateName { get; set; }   // Razão Social

        [JsonPropertyName("tradeName")]
        public required string TradeName { get; set; }       // Nome Fantasia

        [JsonPropertyName("cnpj")]
        public required string Cnpj { get; set; }

        [JsonPropertyName("stateRegistration")]
        public string? StateRegistration { get; set; }

        [JsonPropertyName("email")]
        public required string Email { get; set; }

        [JsonPropertyName("phone")]
        public required string Phone { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("addresses")]
        public required List<AddressResponse> Addresses { get; set; }
    }
}
