using System.ComponentModel.DataAnnotations;

namespace SellGold.Promotions.Application.Contracts.DTOs.Requests
{
    public sealed class RedeemCashbackRequest
    {
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }
    }
}
