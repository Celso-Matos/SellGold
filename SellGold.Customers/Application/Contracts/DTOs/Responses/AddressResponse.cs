namespace SellGold.Customers.Application.Contracts.DTOs.Responses
{
    public class AddressResponse
    {
        public string Street { get; init; } = string.Empty;
        public string Number { get; init; } = string.Empty;
        public string? Complement { get; init; }

        public string District { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;
        public string State { get; init; } = string.Empty;

        public string ZipCode { get; init; } = string.Empty;
        public string Country { get; init; } = string.Empty;

        public string Type { get; init; } = string.Empty;
    }
}
