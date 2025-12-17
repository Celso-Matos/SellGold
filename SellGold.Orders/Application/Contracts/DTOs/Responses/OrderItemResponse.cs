using System.Text.Json.Serialization;

namespace SellGold.Orders.Application.Contracts.DTOs.Responses
{
    public class OrderItemResponse
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }

    }
}
