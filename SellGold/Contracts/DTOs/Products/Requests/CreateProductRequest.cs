using System.ComponentModel.DataAnnotations;

namespace SellGold.Contracts.DTOs.Products.Requests
{
    public class CreateProductRequest
    {
        [Required(ErrorMessage = "Nome do produto é obrigatório")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Código de barras é obrigatório")]
        public required string Barcode { get; set; }

        [Required(ErrorMessage = "Tipo de código de barras é obrigatório")]
        public required string BarcodeType { get; set; }
    }
}
