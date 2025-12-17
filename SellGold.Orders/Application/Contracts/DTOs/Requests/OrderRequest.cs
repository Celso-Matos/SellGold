namespace SellGold.Orders.Application.Contracts.DTOs.Requests
{
    public class OrderRequest
    {
        // Required fields
        public Guid OrderId { get; private set; } = Guid.NewGuid();
        public Guid CustomerId { get; set; } // Required (foreign key to Customer)
        public DateTime Date { get; set; } = DateTime.Now;
        public List<OrderItemRedponse> OrderItems { get; set; } = new List<OrderItemRedponse>();
        public OrderStatus Status { get; private set; } = OrderStatus.Open;

        // Calculated field
        public decimal TotalValue => OrderItems.Sum(i => i.Quantity * i.UnitPrice);

        // Domain methods
        public void Pay() => Status = OrderStatus.Paid;
        public void Cancel() => Status = OrderStatus.Canceled;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }

    public enum OrderStatus
    {
        Open,
        Paid,
        Canceled
    }

}
