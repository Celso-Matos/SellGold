using System.ComponentModel.DataAnnotations;

namespace SellGold.Promotions.Application.Contracts.DTOs.Requests
{
    public sealed class CreateCashbackAccountRequest
    {
        [Required]
        public Guid CustomerId { get; set; }
    }
}
