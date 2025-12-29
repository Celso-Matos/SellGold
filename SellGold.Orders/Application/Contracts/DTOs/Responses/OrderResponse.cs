using System.Text.Json.Serialization;

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

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("totalValue")]
        public decimal TotalValue { get; set; }

        [JsonPropertyName("items")]
        public List<OrderItemResponse> Items { get; set; } = new();

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

    }   


}
