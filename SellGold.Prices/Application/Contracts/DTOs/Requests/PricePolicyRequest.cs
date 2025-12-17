using System.ComponentModel.DataAnnotations;

namespace SellGold.Prices.Application.Contracts.DTOs.Requests
{
    public class PricePolicyRequest
    {
        [Required]
        public Guid PricePolicyId { get; set; }

        [Required]
        public int Strategy { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "As regras devem ter no máximo 500 caracteres.")]
        public string Rules { get; set; } = string.Empty;
    }
}
