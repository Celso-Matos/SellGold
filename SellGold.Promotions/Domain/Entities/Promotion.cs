using SellGold.Promotions.Domain.Exceptions;

namespace SellGold.Promotions.Domain.Entities
{
    public sealed class Promotion
    {
        // EF Core
        protected Promotion() { }

        private Promotion(
            Guid promotionId,
            string name,
            DateTime startDate,
            DateTime endDate,
            decimal discountPercentage,
            string description,
            DateTime createdAt,
            DateTime updatedAt)
        {
            PromotionId = promotionId;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            DiscountPercentage = discountPercentage;
            Description = description;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        // =========================
        // Factory Method (DDD)
        // =========================
        public static Promotion Create(
            string name,
            DateTime startDate,
            DateTime endDate,
            decimal discountPercentage,
            string? description = null)
        {
            Validate(name, startDate, endDate, discountPercentage);

            var now = DateTime.UtcNow;

            return new Promotion(
                Guid.NewGuid(),
                name.Trim(),
                startDate,
                endDate,
                discountPercentage,
                description?.Trim() ?? string.Empty,
                now,
                now
            );
        }

        // =========================
        // State
        // =========================
        public Guid PromotionId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public decimal DiscountPercentage { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // =========================
        // Behavior (DDD)
        // =========================
        public void Update(
            string name,
            DateTime startDate,
            DateTime endDate,
            decimal discountPercentage,
            string? description)
        {
            Validate(name, startDate, endDate, discountPercentage);

            Name = name.Trim();
            StartDate = startDate;
            EndDate = endDate;
            DiscountPercentage = discountPercentage;
            Description = description?.Trim() ?? string.Empty;
            UpdatedAt = DateTime.UtcNow;
        }

        public bool IsActive(DateTime referenceDate)
            => referenceDate >= StartDate && referenceDate <= EndDate;

        // =========================
        // Invariants
        // =========================
        private static void Validate(
            string name,
            DateTime startDate,
            DateTime endDate,
            decimal discountPercentage)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("O nome da promoção é obrigatório.");

            if (startDate >= endDate)
                throw new DomainException("A data inicial deve ser menor que a data final.");

            if (discountPercentage <= 0 || discountPercentage > 100)
                throw new DomainException("O percentual de desconto deve estar entre 0 e 100.");
        }
    }
}
