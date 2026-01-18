
using SellGold.Products.Domain.Exceptions;

namespace SellGold.Products.Domain.Entities
{
    public class Product
    {
        protected Product()
        {
            Name = null!;
            Description = null!;
        } // EF Core

        public Product(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Nome do produto é obrigatório.");

            ProductId = Guid.NewGuid();
            Name = name;
            Description = description;
            IsActive = true;
        }
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public List<ProductBarcode> Barcodes { get; set; } = new();

        public void Activate()
        {
            IsActive = true;
            Touch();
        }

        public void Deactivate()
        {
            IsActive = false;
            Touch();
        }

        private void Touch()
        {
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
