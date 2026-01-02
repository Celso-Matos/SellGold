using CommunityToolkit.Mvvm.Input;
using MediatR;
using SellGold.Application.Customers.Commands;
using SellGold.Contracts.DTOs.Customers.Requests;
using SellGold.Mappings.Customers;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using static SellGold.PageModels.Customers.CustomerPageModel;

namespace SellGold.PageModels.Customers
{
    public class CustomerPageModel : BindableObject
    {
        private readonly IMediator _mediator;
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string NewStreet { get; set; } = string.Empty;
        public string NewCity { get; set; } = string.Empty;
        public string NewZipCode { get; set; }= string.Empty;
        public string AddressType { get; set; } = string.Empty;
        public ObservableCollection<OptionItem> OptionsAddressType { get; set; }

        public class OptionItem
        {
            public string NameAddressType { get; set; } = string.Empty;
            public bool IsSelected { get; set; }
        }
        
        public ObservableCollection<CreateAddressRequest> Addresses { get; set; } = new ObservableCollection<CreateAddressRequest>();

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        // Command de Ação
        public IAsyncRelayCommand SaveCommand { get; }

        public IRelayCommand AddAddressCommand { get; }

        public CustomerPageModel(IMediator mediator)
        {
            _mediator = mediator;
            SaveCommand = new AsyncRelayCommand(SaveAsync);
            AddAddressCommand = new RelayCommand(AddAddress);
            
            OptionsAddressType = new ObservableCollection<OptionItem>
            {
                new OptionItem { NameAddressType = "Residencial", IsSelected = false },
                new OptionItem { NameAddressType = "Entrega", IsSelected = true },
                new OptionItem { NameAddressType = "Cobrança/Faturamento", IsSelected = false },
                new OptionItem { NameAddressType = "Fiscal", IsSelected = false }
            };

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

        public void AddAddress()
        {
            if (string.IsNullOrWhiteSpace(NewStreet) || string.IsNullOrWhiteSpace(NewCity) || string.IsNullOrWhiteSpace(NewZipCode))
            {
                ErrorMessage = "Please fill in all address fields.";
                return;
            }

            if(OptionsAddressType.Count == 0 || !OptionsAddressType.Any(o => o.IsSelected))
            {
                ErrorMessage = "Please select an address type.";
                return;
            }

            foreach (var option in OptionsAddressType)
            {
                if (option.IsSelected)
                {
                    var newAddress = new CreateAddressRequest
                    {
                        Street = NewStreet,
                        City = NewCity,
                        ZipCode = NewZipCode,
                        AddressType = option.NameAddressType
                    };
                    Addresses.Add(newAddress);
                    
                    break;
                }
            }

            
            CleanFieldsAddress();


        }
        private void CleanFieldsAddress()
        {
            NewStreet = string.Empty;
            NewCity = string.Empty;
            NewZipCode = string.Empty;
            OnPropertyChanged(nameof(Addresses));
            OnPropertyChanged(nameof(NewStreet));
            OnPropertyChanged(nameof(NewCity));
            OnPropertyChanged(nameof(NewZipCode));
            ErrorMessage = null; // Limpar mensagem de erro
        }   
    }
}
