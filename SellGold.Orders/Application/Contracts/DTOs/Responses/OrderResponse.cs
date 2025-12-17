using System.Text.Json.Serialization;
using SellGold.Orders.Application.Contracts.DTOs.Responses;

namespace SellGold.Orders.Application.Contracts.DTOs.Responses
{
    public class OrderResponse
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; } = string.Empty;

        public decimal TotalValue { get; set; }

        public List<OrderItemResponse> Items { get; set; } = new();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }   


}
