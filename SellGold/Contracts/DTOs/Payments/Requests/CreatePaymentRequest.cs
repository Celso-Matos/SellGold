namespace SellGold.Contracts.DTOs.Payments.Requests
{
    public partial class CreatePaymentRequest
    {
        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Range(0D, 79228162514264337593543950335D)]
        public double Amount { get; set; }

        [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(3)]
        public string Currency { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("paymentMethodId", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public System.Guid PaymentMethodId { get; set; }

        [Newtonsoft.Json.JsonProperty("invoiceNumber", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("invoiceCurrency", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.StringLength(3)]
        public string InvoiceCurrency { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("invoiceAmount", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.Range(0D, 79228162514264337593543950335D)]
        public double InvoiceAmount { get; set; }
    }
}
