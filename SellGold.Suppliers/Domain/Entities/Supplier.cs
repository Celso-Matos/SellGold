using SellGold.Suppliers.Domain.Exceptions;
using SellGold.Suppliers.Domain.ValueObjects;

namespace SellGold.Suppliers.Domain.Entities
{
    public class Supplier
    {
        public Guid SupplierId { get; private set; }

        public string CorporateName { get; private set; } = null!;
        public string TradeName { get; private set; } = null!;
        public string Cnpj { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Phone { get; private set; } = null!;

        public string? StateRegistration { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private readonly List<Address> _addresses = new();
        public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();

        protected Supplier() { } // EF

        public Supplier(
            string corporateName,
            string tradeName,
            string cnpj,
            string email,
            string phone,
            string? stateRegistration = null)
        {

            SupplierId = Guid.NewGuid();

            SetCorporateName(corporateName);
            SetTradeName(tradeName);
            SetCnpj(cnpj);
            SetEmail(email);
            SetPhone(phone);

            StateRegistration = stateRegistration;
            IsActive = true;

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        // -------------------------
        // Comportamentos do domínio
        // -------------------------

        public void UpdateContact(string email, string phone)
        {
            SetEmail(email);
            SetPhone(phone);
            Touch();
        }

        public void AddAddress(Address address)
        {
            if (_addresses.Contains(address))
                return;

            _addresses.Add(address);
            Touch();
        }

        public void RemoveAddress(Address address)
        {
            _addresses.Remove(address);
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

        // -------------------------
        // Regras internas
        // -------------------------

        private void SetCorporateName(string corporateName)
        {
            if (string.IsNullOrWhiteSpace(corporateName))
                throw new DomainException("Razão Social é obrigatória.");

            CorporateName = corporateName;
        }

        private void SetTradeName(string tradeName)
        {
            if (string.IsNullOrWhiteSpace(tradeName))
                throw new DomainException("Nome Fantasia é obrigatório.");

            TradeName = tradeName;
        }

        private void SetCnpj(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                throw new DomainException("CNPJ é obrigatório.");

            Cnpj = cnpj;
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new DomainException("Email é obrigatório.");

            Email = email;
        }

        private void SetPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                throw new DomainException("Telefone é obrigatório.");

            Phone = phone;
        }

        private void Touch()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
