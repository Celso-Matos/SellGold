using System.ComponentModel.DataAnnotations;

namespace SellGold.Products.Application.Contracts.DTOs.Requests
{
    public class CreateProductRequest
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public required string Name { get; set; } = string.Empty;       
        public string? Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;

        [Required(ErrorMessage = "Códgo de Barras é obrigatório")]
        public string Barcode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tipo do Códgo de Barras é obrigatório")]
        public string BarcodeType { get; set; } = string.Empty;

        public List<string> Barcodes { get; set; } = new();


    }
}
