using System.ComponentModel.DataAnnotations;

namespace SellGold.Promotions.Application.Contracts.DTOs.Requests
{
    public sealed class RedeemPointsRequest
    {
        [Range(1, int.MaxValue)]
        public int Points { get; set; }
    }
}
