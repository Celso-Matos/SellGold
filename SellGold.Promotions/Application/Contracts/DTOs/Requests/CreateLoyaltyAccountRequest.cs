using System.ComponentModel.DataAnnotations;

namespace SellGold.Promotions.Application.Contracts.DTOs.Requests
{
    public class CreateLoyaltyAccountRequest
    {
        [Required]
        public Guid CustomerId { get; set; }
    }
}
