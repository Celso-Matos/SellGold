using System.ComponentModel.DataAnnotations;

namespace SellGold.Products.Application.Contracts.DTOs.Requests
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public required string Name { get; set; }        
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Códgo de Barras é obrigatório")]
        public required string Barcode { get; set; }

        [Required(ErrorMessage = "Tipo do Códgo de Barras é obrigatório")]
        public required string BarcodeType { get; set; }

    }
}
