using System.ComponentModel.DataAnnotations;
using SellGold.Orders.Domain.Enums;

namespace SellGold.Orders.Application.Contracts.DTOs.Requests
{
    public class CreateOrderRequest
    {
        [Required(ErrorMessage = "O Cliente é obrigatório.")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "Os itens do pedido são obrigatórios.")]
        [MinLength(1, ErrorMessage = "O pedido deve conter ao menos um item.")]
        public List<CreateOrderItemRequest> Items { get; set; } = new();

        // Opcional: permite agendamento do pedido
        public DateTime? OrderDate { get; set; }

    }    

}
