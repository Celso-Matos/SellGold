using CommunityToolkit.Mvvm.Input;
using SellGold.Application.Suppliers.Commands;
using SellGold.Mappings.Suppliers;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SellGold.PageModels.Suppliers
{
    public class SupplierPageModel : BindableObject
    {
        private readonly IMediator _mediator;
        
        // Propriedades ligadas aos campos da tela
        public string CorporateName { get; set; }   // Razão Social
        public string TradeName { get; set; }       // Nome Fantasia
        public string Cnpj { get; set; }
        public string? StateRegistration { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string Street { get; set; }       
        public string Number { get; set; }
        public string? Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }
        // Command de Ação
        public IAsyncRelayCommand SaveCommand { get; }
        public SupplierPageModel(IMediator mediator)
        {
            _mediator = mediator;
            SaveCommand = new AsyncRelayCommand(SaveAsync);
        }
        private async Task SaveAsync()
        {
            try
            {
                var supplierRequest = SupplierMapping.ToRequest(this);
                var result = await _mediator.Send(new CreateSupplierCommand(supplierRequest));
                if (!result)
                {
                    ErrorMessage = "Failed to save supplier.";
                    return;
                }
                // Limpa os campos
                CleanFields();
            }
            catch (ValidationException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
            }
        }
        private void CleanFields()
        {
            CorporateName = string.Empty;
            TradeName = string.Empty;
            Cnpj = string.Empty;
            StateRegistration = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            IsActive = false;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Street = string.Empty;
            Number = string.Empty;
            Complement = string.Empty;
            District = string.Empty;
            City = string.Empty;
            State = string.Empty;
            ZipCode = string.Empty;
            Country = string.Empty;
            OnPropertyChanged(nameof(CorporateName));
            OnPropertyChanged(nameof(TradeName));
            OnPropertyChanged(nameof(Cnpj));
            OnPropertyChanged(nameof(StateRegistration));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(Phone));
            OnPropertyChanged(nameof(City));
            OnPropertyChanged(nameof(CreatedAt));
            OnPropertyChanged(nameof(UpdatedAt));
            OnPropertyChanged(nameof(Street));
            OnPropertyChanged(nameof(Number));
            OnPropertyChanged(nameof(Complement));
            OnPropertyChanged(nameof(District));
            OnPropertyChanged(nameof(City));
            OnPropertyChanged(nameof(State));
            OnPropertyChanged(nameof(ZipCode));
            OnPropertyChanged(nameof(Country));
        }        
    }
}
