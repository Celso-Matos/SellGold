using CommunityToolkit.Mvvm.Input;
using SellGold.Application.Payments.Commands;
using SellGold.Mappings.Payments;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SellGold.PageModels.Payments
{
    public class PaymentPageModel : BindableObject
    {
        private readonly IMediator _mediator;
        public double Amount { get; set; }
        public string Currency { get; set; } = "BRL";
        public Guid PaymentMethodId { get; set; }
        public string InvoiceNumber { get; set; } = string.Empty;
        public string InvoiceCurrency { get; set; } = "BRL";
        public double InvoiceAmount { get; set; }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public IAsyncRelayCommand SaveCommand { get; }

        public PaymentPageModel(IMediator mediator)
        {
            _mediator = mediator;
            SaveCommand = new AsyncRelayCommand(SaveAsync);
        }

        private async Task SaveAsync()
        {
            try
            {
                var paymentRequest = PaymentMapping.ToRequest(this);
                var result = await _mediator.Send(new CreatePaymentCommand(paymentRequest));
                if (!result)
                {
                    ErrorMessage = "Failed to save payment.";
                    return;
                }
                CleanFields();
            }
            catch (ValidationException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Unexpected error: {ex.Message}";
            }
        }

        private void CleanFields()
        {
            Amount = 0;
            Currency = "BRL";
            PaymentMethodId = Guid.Empty;
            InvoiceNumber = string.Empty;
            InvoiceCurrency = "BRL";
            InvoiceAmount = 0;
        }
    }
}
