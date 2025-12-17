namespace SellGold.Customers.Domain.Entities
{
    public class Customer
    {
        // Required fields
        public Guid CustomerId { get; private set; } = Guid.NewGuid();
        public required string Name { get; set; } // Required
        public required string Document { get; set; } // Required (CPF/CNPJ)
        

        // Optional fields
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public List<Address> Addresses { get; private set; } = new List<Address>();
        public bool IsActive { get; private set; } = true;

        // Domain methods
        public void Deactivate() => IsActive = false;
        public void Activate() => IsActive = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
