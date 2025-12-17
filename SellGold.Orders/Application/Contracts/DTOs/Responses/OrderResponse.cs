using System.Text.Json.Serialization;
using SellGold.Orders.Application.Contracts.DTOs.Responses;

namespace SellGold.Orders.Application.Contracts.DTOs.Responses
{
    public class OrderResponse
    {
        [JsonPropertyName("orderId")]
        public Guid OrderId { get; set; }

        [JsonPropertyName("customerId")]
        public Guid CustomerId { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("orderItems")]
        public List<OrderItemResponse> OrderItems { get; set; } = new List<OrderItemResponse>();

        [JsonPropertyName("status")]
        public OrderStatus Status { get; set; }

        [JsonPropertyName("totalValue")]
        public decimal TotalValue { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }

    public enum OrderStatus
    {
        Open,
        Paid,
        Canceled
    }


}
