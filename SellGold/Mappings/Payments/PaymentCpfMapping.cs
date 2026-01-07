using SellGold.Contracts.DTOs.Payments.Requests;
using SellGold.PageModels.Payments;

namespace SellGold.Mappings.Payments
{
    public static class PaymentCpfMapping
    {
        public static PaymentCpfRequest ToRequest(ListPaymentCpfPageModel model) =>
            new PaymentCpfRequest
            {
                CPF = model.Document
            };
    }
}
