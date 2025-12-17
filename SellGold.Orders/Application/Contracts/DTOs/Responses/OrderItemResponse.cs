using System.Text.Json.Serialization;

namespace SellGold.Orders.Application.Contracts.DTOs.Responses
{
    public class OrderItemResponse
    {
        [JsonPropertyName("orderItemId")]
        public Guid OrderItemId { get; set; }

        [JsonPropertyName("productId")]
        public Guid ProductId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("unitPrice")]
        public decimal UnitPrice { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }


    }
}
