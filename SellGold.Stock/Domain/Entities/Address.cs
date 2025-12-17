namespace SellGold.Stock.Domain.Entities
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public Guid StockLocationId { get; set; }
        public required string Street { get; set; }
        public required string Number { get; set; }
        public string? Complement { get; set; }
        public required string District { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required string Country { get; set; }
        public string Type { get; set; } = string.Empty; //Residential, Commercial, etc.
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
