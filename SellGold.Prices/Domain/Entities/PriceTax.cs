using System;
using System.ComponentModel.DataAnnotations;

namespace SellGold.Prices.Domain.Entities
{
    public class PriceTax
    {
        [Key]
        public Guid PriceTaxId { get; set; }
        public required string Name { get; set; }   // Ex: ICMS, IPI
        public required decimal Rate { get; set; }  // percentual
        public required Guid PriceId { get; set; }
        public Price? Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
