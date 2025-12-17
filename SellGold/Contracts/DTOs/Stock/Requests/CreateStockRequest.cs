using System.ComponentModel.DataAnnotations;

namespace SellGold.Contracts.DTOs.Stock.Requests
{
    public class CreateStockRequest
    {
        public required Guid StockProductId { get; set; }

        [Required(ErrorMessage = "Produto é obrigatório")]
        public required Guid ProductId { get; set; }

        [Required(ErrorMessage = "Quantidade Atual é obrigatório")]
        public required int CurrentQuantity { get; set; }

        [Required(ErrorMessage = "Data da Movimentação é obrigatório")]
        public required DateTime DateMovement { get; set; }

        [Required(ErrorMessage = "Quantidade Movimentada é obrigatório")]
        public required int AmountMovement { get; set; }

        [Required(ErrorMessage = "Tipo de Movimento é obrigatório")]
        public required int MovementType { get; set; }
        public string? Observation { get; set; }

        [Required(ErrorMessage = "Local é obrigatório")]
        public required string StockLocationName { get; set; }

        [Required(ErrorMessage = "Logradouro do Local é obrigatório")]
        public required string Street { get; set; }

        [Required(ErrorMessage = "Número do Local é obrigatório")]
        public required string Number { get; set; }
        public string? Complement { get; set; }

        [Required(ErrorMessage = "Bairro do Local é obrigatório")]
        public required string District { get; set; }

        [Required(ErrorMessage = "Cidade do Local é obrigatório")]
        public required string City { get; set; }

        [Required(ErrorMessage = "Estado do Local é obrigatório")]
        public required string State { get; set; }

        [Required(ErrorMessage = "CEP do Local é obrigatório")]
        public required string ZipCode { get; set; }

        [Required(ErrorMessage = "Pais do Local é obrigatório")]
        public required string Country { get; set; }
    }
}
