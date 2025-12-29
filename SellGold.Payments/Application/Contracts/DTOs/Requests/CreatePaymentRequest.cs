using System.ComponentModel.DataAnnotations;

namespace SellGold.Payments.Application.Contracts.DTOs.Requests
{
    public class CreatePaymentRequest
    {
        // Valor e moeda
        [Required(ErrorMessage = "O Valor é obrigatório")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "A moeda é obrigatório")]
        [StringLength(3, ErrorMessage = "A moeda deve ter até 3 caracteres (ISO).")]
        public string Currency { get; set; } = string.Empty;

        // Método de pagamento
        [Required(ErrorMessage = "O método de pagemento é obrigatório")]
        public Guid PaymentMethodId { get; set; }

        // Dados da fatura/recibo
        [Required(ErrorMessage = "O Número da fatura é obrigatório")]
        public string InvoiceNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "A moeda na fatura é obrigatório")]
        [StringLength(3, ErrorMessage = "A moeda na fatura deve ter até 3 caracteres (ISO).")]
        public string InvoiceCurrency { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Valor na fatura é obrigatório")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "O valor na fatura deve ser maior que zero.")]
        public decimal InvoiceAmount { get; set; }        

    }
}
