using System.Text.Json.Serialization;

namespace SellGold.Customers.Application.Contracts.DTOs.Responses
{
    public class AddressResponse
    {
        [JsonPropertyName("street")]
        public string Street { get; init; } = string.Empty;

        [JsonPropertyName("number")]
        public string Number { get; init; } = string.Empty;

        [JsonPropertyName("complement")]
        public string? Complement { get; init; }

        [JsonPropertyName("district")]
        public string District { get; init; } = string.Empty;

        [JsonPropertyName("city")]
        public string City { get; init; } = string.Empty;

        [JsonPropertyName("state")]
        public string State { get; init; } = string.Empty;

        [JsonPropertyName("zipCode")]
        public string ZipCode { get; init; } = string.Empty;

        [JsonPropertyName("country")]
        public string Country { get; init; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; init; } = string.Empty;
    }
}
