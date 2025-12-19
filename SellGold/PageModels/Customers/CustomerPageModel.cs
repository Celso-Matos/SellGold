using CommunityToolkit.Mvvm.Input;
using SellGold.Application.Customers.Commands;
using SellGold.Contracts.DTOs.Customers.Requests;
using SellGold.Mappings.Customers;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SellGold.PageModels.Customers
{
    public class CustomerPageModel : BindableObject
    {
        private readonly IMediator _mediator;
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public System.Collections.Generic.ICollection<CreateAddressRequest> Addresses { get; set; } = new List<CreateAddressRequest>();

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        // Command de Ação
        public IAsyncRelayCommand SaveCommand { get; }
        public CustomerPageModel(IMediator mediator)
        {
            _mediator = mediator;
            SaveCommand = new AsyncRelayCommand(SaveAsync);

        }
        private async Task SaveAsync()
        {
            try
            {
                var CustomerRequest = CustomerMapping.ToRequest(this);
                var result = await _mediator.Send(new CreateCustomerCommand(CustomerRequest));
                if (!result)
                {
                    ErrorMessage = "Failed to save Customer.";
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
            Name = string.Empty;
            Document = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Addresses.Clear();
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Document));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(Phone));
            OnPropertyChanged(nameof(Addresses));
        }
    }
}
