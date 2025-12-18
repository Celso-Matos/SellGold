using SellGold.Orders.Domain.Exceptions;

namespace SellGold.Orders.Domain.Entities
{
    public class OrderItem
    {
        protected OrderItem() { }

        public OrderItem(Guid productId, int quantity, decimal unitPrice)
        {
            if (quantity <= 0)
                throw new DomainException("Quantidade inválida.");

            if (unitPrice <= 0)
                throw new DomainException("Preço inválido.");

            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public decimal Total => Quantity * UnitPrice;
    }
}
