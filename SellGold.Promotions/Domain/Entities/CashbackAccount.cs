using SellGold.Promotions.Domain.Exceptions;

namespace SellGold.Promotions.Domain.Entities
{
    public class CashbackAccount
    {
        // EF Core
        protected CashbackAccount() { }

        public CashbackAccount(Guid customerId)
        {
            if (customerId == Guid.Empty)
                throw new DomainException("Cliente inválido.");

            CashbackAccountId = Guid.NewGuid();
            CustomerId = customerId;
            Balance = 0m;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid CashbackAccountId { get; private set; }
        public Guid CustomerId { get; private set; }
        public decimal Balance { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // Behavior (DDD)

        public void AccumulateCashback(decimal purchaseValue)
        {
            if (purchaseValue <= 0)
                throw new DomainException("Valor da compra deve ser maior que zero.");

            // Regra explícita de negócio
            // Cashback fixo de 5%
            var cashbackAmount = purchaseValue * 0.05m;

            if (cashbackAmount <= 0)
                return;

            Balance += cashbackAmount;
            UpdatedAt = DateTime.UtcNow;
        }

        public void RedeemCashback(decimal amount)
        {
            if (amount <= 0)
                throw new DomainException("Valor para resgate inválido.");

            if (amount > Balance)
                throw new DomainException("Saldo de cashback insuficiente.");

            Balance -= amount;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
