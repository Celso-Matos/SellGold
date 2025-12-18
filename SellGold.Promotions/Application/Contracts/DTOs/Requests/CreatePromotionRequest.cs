using System.ComponentModel.DataAnnotations;

namespace SellGold.Promotions.Application.Contracts.DTOs.Requests
{
    public class CreatePromotionRequest
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Range(0.01, 100)]
        public decimal DiscountPercentage { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
