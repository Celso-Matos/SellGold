using System.Text.Json.Serialization;

namespace SellGold.Stock.Application.Contracts.DTOs.Responses
{
    public class AddressResponse
    {
        [JsonPropertyName("addressId")]
        public Guid AddressId { get; init; }

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

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; init; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; init; }
    }
}