using SellGold.Contracts.DTOs.Payments.Requests;
using SellGold.PageModels.Payments;

namespace SellGold.Mappings.Payments
{
    public static class PaymentMapping
    {
        public static CreatePaymentRequest ToRequest(PaymentPageModel pageModel)
        {
            return new CreatePaymentRequest
            {
                Amount = pageModel.Amount,
                Currency = pageModel.Currency,
                PaymentMethodId = pageModel.PaymentMethodId,
                InvoiceNumber = pageModel.InvoiceNumber,
                InvoiceCurrency = pageModel.InvoiceCurrency,
                InvoiceAmount = pageModel.InvoiceAmount
            };
        }
    }
}
