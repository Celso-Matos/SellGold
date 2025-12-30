namespace SellGold.Contracts.DTOs.Payments.Responses
{
    public partial class PaymentResponse
    {
        [Newtonsoft.Json.JsonProperty("paymentId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid PaymentId { get; set; }

        [Newtonsoft.Json.JsonProperty("amount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Amount { get; set; }

        [Newtonsoft.Json.JsonProperty("currency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Currency { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("paymentMethodId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid PaymentMethodId { get; set; }

        [Newtonsoft.Json.JsonProperty("paymentMethodCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PaymentMethodCode { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("paymentMethodType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PaymentMethodType { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Status { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("createdAt", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset CreatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("completedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? CompletedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("invoiceId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Guid InvoiceId { get; set; }

        [Newtonsoft.Json.JsonProperty("invoiceNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("invoiceAmount", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double InvoiceAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("invoiceCurrency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string InvoiceCurrency { get; set; } = string.Empty;

        [Newtonsoft.Json.JsonProperty("invoiceStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string InvoiceStatus { get; set; } = string.Empty;
    }
}
