using System.ComponentModel.DataAnnotations;

namespace SellGold.Prices.Application.Contracts.DTOs.Requests
{
    public class PriceTaxRequest
    {
        [Required]
        public Guid PriceTaxId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O nome do imposto deve ter no máximo 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0.0, 100.0, ErrorMessage = "A taxa deve estar entre 0 e 100%.")]
        public decimal Rate { get; set; }

        [Required]
        public Guid PriceId { get; set; }
    }
}
