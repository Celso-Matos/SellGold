using SellGold.Customers.Domain.Common;
using SellGold.Customers.Domain.ValueObject;

namespace SellGold.Customers.Domain.Entities
{
    public class Customer
    {
        private readonly List<Address> _addresses = new();

        protected Customer() { } // EF Core

        public Customer(string name, string document, string email, string phone)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Nome do cliente é obrigatório.");

            if (string.IsNullOrWhiteSpace(document))
                throw new DomainException("Documento é obrigatório.");

            CustomerId = Guid.NewGuid();
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            IsActive = true;

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid CustomerId { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }

        public string Email { get; private set; }
        public string Phone { get; private set; }

        public bool IsActive { get; private set; }

        public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // ======================
        // Domain Behaviors
        // ======================

        public void UpdateContact(string email, string phone)
        {
            Email = email;
            Phone = phone;
            Touch();
        }

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

        public void AddAddress(Address address)
        {
            if (address == null)
                throw new DomainException("Endereço inválido.");

            _addresses.Add(address);
            Touch();
        }

        public void RemoveAddress(Address address)
        {
            _addresses.Remove(address);
            Touch();
        }

        private void Touch()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
