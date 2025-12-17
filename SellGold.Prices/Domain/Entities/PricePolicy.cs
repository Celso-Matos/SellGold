using System;
using System.ComponentModel.DataAnnotations;

namespace SellGold.Prices.Domain.Entities
{
    public class PricePolicy
    {
        [Key]
        public Guid PricePolicyId { get; set; }
        public required Strategy Strategy { get; set; }
        public required string Rules { get; set; } // pode ser JSON ou texto
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
    public enum Strategy
    {
        CustoLucro,
        Fixo,
        Dinamico
    }

}
