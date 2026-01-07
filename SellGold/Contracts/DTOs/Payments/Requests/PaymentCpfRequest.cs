
using System.ComponentModel.DataAnnotations;

namespace SellGold.Contracts.DTOs.Payments.Requests
{
    public partial class PaymentCpfRequest
    {
        [Required(ErrorMessage = "CPF é obrigatório")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$",ErrorMessage = "CPF deve estar no formato XXX.XXX.XXX-XX")]
        public string CPF { get; set; } = string.Empty;

    }
}
