using SellGold.Customers.Domain.Exceptions;

namespace SellGold.Promotions.Domain.Entities
{
    public class LoyaltyAccount
    {
        // EF Core
        protected LoyaltyAccount() { }

        public LoyaltyAccount(Guid customerId)
        {
            if (customerId == Guid.Empty)
                throw new DomainException("Cliente inválido.");

            LoyaltyAccountId = Guid.NewGuid();
            CustomerId = customerId;
            Points = 0;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid LoyaltyAccountId { get; private set; }
        public Guid CustomerId { get; private set; }
        public int Points { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // Behavior (DDD)

        public void AccumulatePoints(decimal purchaseValue)
        {
            if (purchaseValue <= 0)
                throw new DomainException("Valor da compra deve ser maior que zero.");

            // Regra explícita de negócio
            // 1 ponto a cada R$10,00
            var earnedPoints = (int)(purchaseValue / 10);

            if (earnedPoints <= 0)
                return;

            Points += earnedPoints;
            UpdatedAt = DateTime.UtcNow;
        }

        public void RedeemPoints(int points)
        {
            if (points <= 0)
                throw new DomainException("Quantidade de pontos inválida.");

            if (points > Points)
                throw new DomainException("Saldo de pontos insuficiente.");

            Points -= points;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
