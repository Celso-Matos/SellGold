using SellGold.Orders.Domain.Enums;
using SellGold.Orders.Domain.Exceptions;

namespace SellGold.Orders.Domain.Entities
{
    public class Order
    {
        private readonly List<OrderItem> _items = new();

        protected Order() { } // EF Core

        public Order(Guid customerId, IEnumerable<OrderItem> items, DateTime orderDate)
        {
            if (customerId == Guid.Empty)
                throw new ArgumentException("CustomerId inválido.");

            if (items == null || !items.Any())
                throw new DomainException("O pedido deve conter ao menos um item.");

            OrderId = Guid.NewGuid();
            CustomerId = customerId;
            Date = orderDate;
            Status = OrderStatus.Open;

            _items.AddRange(items);

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid OrderId { get; private set; }
        public Guid CustomerId { get; private set; }
        public DateTime Date { get; private set; }

        public OrderStatus Status { get; private set; }

        public IReadOnlyCollection<OrderItem> OrderItems => _items.AsReadOnly();

        public decimal TotalValue => _items.Sum(i => i.Total);

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        // ======================
        // Domain Behaviors
        // ======================

        public void Pay()
        {
            if (Status == OrderStatus.Canceled)
                throw new DomainException("Pedido cancelado não pode ser pago.");

            if (Status == OrderStatus.Paid)
                throw new DomainException("Pedido já foi pago.");

            Status = OrderStatus.Paid;
            Touch();
        }

        public void Cancel()
        {
            if (Status == OrderStatus.Paid)
                throw new DomainException("Pedido pago não pode ser cancelado.");

            Status = OrderStatus.Canceled;
            Touch();
        }

        public void AddItem(OrderItem item)
        {
            if (Status != OrderStatus.Open)
                throw new DomainException("Não é possível alterar itens após o pagamento.");

            _items.Add(item);
            Touch();
        }

        private void Touch()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
