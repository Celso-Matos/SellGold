
namespace SellGold.Suppliers.Domain.Entities
{
    public class Supplier
    {
        public Guid SupplierId { get; set; }        
        public required string CorporateName { get; set; }   // Razão Social
        public required string TradeName { get; set; }       // Nome Fantasia
        public required string Cnpj { get; set; }
        public string? StateRegistration { get; set; }        
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public List<Address> Addresses { get; set; } = new();

    }
}
