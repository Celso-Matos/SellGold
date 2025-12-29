using System.Text.Json.Serialization;

namespace SellGold.Payments.Application.Contracts.DTOs.Responses
{
    public class PaymentResponse
    {
        [JsonPropertyName("paymentId")]
        public Guid PaymentId { get; set; }

        // Valor e moeda
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;

        // Método de pagamento

        [JsonPropertyName("paymentMethodId")]
        public Guid PaymentMethodId { get; set; }

        [JsonPropertyName("paymentMethodCode")]
        public string PaymentMethodCode { get; set; } = string.Empty;

        [JsonPropertyName("paymentMethodType")]
        public string PaymentMethodType { get; set; } = string.Empty;

        // Status e datas

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("completedAt")]
        public DateTime? CompletedAt { get; set; }

        // Dados da fatura

        [JsonPropertyName("invoiceId")]
        public Guid InvoiceId { get; set; }

        [JsonPropertyName("invoiceNumber")]
        public string InvoiceNumber { get; set; } = string.Empty;

        [JsonPropertyName("invoiceAmount")]
        public decimal InvoiceAmount { get; set; }

        [JsonPropertyName("invoiceCurrency")]
        public string InvoiceCurrency { get; set; } = string.Empty;

        [JsonPropertyName("invoiceStatus")]
        public string InvoiceStatus { get; set; } = string.Empty;

    }
}
