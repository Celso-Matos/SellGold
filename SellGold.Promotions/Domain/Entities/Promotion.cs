using SellGold.Customers.Domain.Exceptions;

namespace SellGold.Promotions.Domain.Entities
{
    public class Promotion
    {
        // EF Core
        protected Promotion() { }

        public Promotion(
            string name,
            DateTime startDate,
            DateTime endDate,
            decimal discountPercentage,
            string? description = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("O nome da promoção é obrigatório.");

            if (startDate >= endDate)
                throw new DomainException("A data inicial deve ser menor que a data final.");

            if (discountPercentage <= 0 || discountPercentage > 100)
                throw new DomainException("O percentual de desconto deve estar entre 0 e 100.");

            PromotionId = Guid.NewGuid();
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            DiscountPercentage = discountPercentage;
            Description = description ?? string.Empty;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid PromotionId { get; private set; }
        public string Name { get; private set; } = null!;
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public decimal DiscountPercentage { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // Behavior (DDD)
        public void Update(
            string name,
            DateTime startDate,
            DateTime endDate,
            decimal discountPercentage,
            string? description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("O nome da promoção é obrigatório.");

            if (startDate >= endDate)
                throw new DomainException("A data inicial deve ser menor que a data final.");

            if (discountPercentage <= 0 || discountPercentage > 100)
                throw new DomainException("O percentual de desconto deve estar entre 0 e 100.");

            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            DiscountPercentage = discountPercentage;
            Description = description ?? string.Empty;
            UpdatedAt = DateTime.UtcNow;
        }

        public bool IsActive(DateTime referenceDate)
            => referenceDate >= StartDate && referenceDate <= EndDate;
    }
}
