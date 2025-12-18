using System.ComponentModel.DataAnnotations;

namespace SellGold.Promotions.Application.Contracts.DTOs.Requests
{
    public sealed class AccumulateCashbackRequest
    {
        [Range(0.01, double.MaxValue)]
        public decimal PurchaseValue { get; set; }
    }
}
