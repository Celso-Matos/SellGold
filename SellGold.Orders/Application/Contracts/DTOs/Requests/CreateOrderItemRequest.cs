using System.ComponentModel.DataAnnotations;

namespace SellGold.Orders.Application.Contracts.DTOs.Requests
{
    public class CreateOrderItemRequest
    {
        [Required(ErrorMessage = "O Produto é obrigatório.")]
        public Guid ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço unitário deve ser maior que zero.")]
        public decimal UnitPrice { get; set; }

    }
}
