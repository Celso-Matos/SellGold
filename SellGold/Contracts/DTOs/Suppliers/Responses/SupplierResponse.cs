using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace SellGold.Contracts.DTOs.Suppliers.Responses
{
    public class SupplierResponse
    {
        [JsonPropertyName("supplierId")]
        public Guid SupplierId { get; set; }

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
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [JsonPropertyName("addresses")]
        public List<AddressResponse> Address { get; set; } = new();
    }
}
