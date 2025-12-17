using SellGold.Prices.Application.Contracts.DTOs.Responses;
using SellGold.Prices.Domain.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace SellGold.Prices.Domain.Entities
{
    public class Price
    {
        [Key]
        public Guid PriceId { get; set; }
        public required PriceMoney BasePrice { get; set; }
        public required ICollection<PriceDiscount> Discounts { get; set; } = new List<PriceDiscount>();
        public required ICollection<PricePolicy> Policies { get; set; } = new List<PricePolicy>();
        public required ICollection<PriceTax> Taxes { get; set; } = new List<PriceTax>();
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
