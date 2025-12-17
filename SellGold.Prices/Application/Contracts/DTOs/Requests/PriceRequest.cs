using System.ComponentModel.DataAnnotations;

namespace SellGold.Prices.Application.Contracts.DTOs.Requests
{
    public class PriceRequest
    {
        
        [Required(ErrorMessage = "O Preço é obrigatório")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal BasePriceAmount { get; set; }

        [Required(ErrorMessage = "A moeda é obrigatório")]
        [StringLength(3, ErrorMessage = "A moeda deve ter até 3 caracteres (ISO).")]
        public string BasePriceCurrency { get; set; } = string.Empty;        
        public List<PriceDiscountRequest> Discounts { get; set; } = new();        
        public List<PricePolicyRequest> Policies { get; set; } = new();        
        public List<PriceTaxRequest> Taxes { get; set; } = new();
    }
}
