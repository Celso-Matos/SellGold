using System;
using System.ComponentModel.DataAnnotations;

namespace SellGold.Prices.Domain.Entities
{
    public class PriceDiscount
    {
        [Key]
        public Guid PriceDiscountId { get; set; }
        public required DiscountType Type { get; set; } // Percentual ou Fixo
        public required decimal Value { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required Guid PriceId { get; set; }
        public Price? Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
    public enum DiscountType
    {
        Percentual,
        Fixo
    }
}
