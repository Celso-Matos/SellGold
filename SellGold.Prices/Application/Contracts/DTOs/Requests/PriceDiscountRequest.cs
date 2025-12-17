using System.ComponentModel.DataAnnotations;

namespace SellGold.Prices.Application.Contracts.DTOs.Requests
{
    public class PriceDiscountRequest
    {
        [Required]
        public Guid PriceDiscountId { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "O valor do desconto deve ser positivo.")]
        public decimal Value { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public Guid PriceId { get; set; }
    }
}
