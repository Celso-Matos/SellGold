using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SellGold.Contracts.DTOs.Suppliers.Responses
{
    public class AddressResponse
    {
        [JsonPropertyName("addressId")]
        public Guid AddressId { get; set; }

        [JsonPropertyName("street")]
        public required string Street { get; set; }

        [JsonPropertyName("number")]
        public required string Number { get; set; }

        [JsonPropertyName("complement")]
        public string? Complement { get; set; }

        [JsonPropertyName("district")]
        public required string District { get; set; }

        [JsonPropertyName("city")]
        public required string City { get; set; }

        [JsonPropertyName("state")]
        public required string State { get; set; }

        [JsonPropertyName("zipCode")]
        public required string ZipCode { get; set; }

        [JsonPropertyName("country")]
        public required string Country { get; set; }
    }
}
