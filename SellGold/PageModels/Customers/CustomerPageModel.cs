using CommunityToolkit.Mvvm.Input;
using FluentValidation;
using MediatR;
using SellGold.Application.Customers.Commands;
using SellGold.Contracts.DTOs.Customers.Requests;
using SellGold.Mappings.Customers;
using SellGold.Services.Customers;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SellGold.PageModels.Customers
{
    public class CustomerPageModel : BindableObject
    {
        private readonly IMediator _mediator;
        private readonly CepService _cepService;

        private readonly IValidator<CreateCustomerRequest> _validator;
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string NewStreet { get; set; } = string.Empty;
        public string NewNumber { get; set; } = string.Empty;
        public string NewComplement { get; set; }= string.Empty;
        public string NewDistrict { get; set; } = string.Empty;
        public string NewCity { get; set; } = string.Empty;
        public string NewState { get; set; } = string.Empty;
        
        private string _newZipCode = string.Empty;

        private bool _isValidatingCep = false;
        public string NewZipCode
        {
            get => _newZipCode;
            set
            {
                if (_newZipCode == value)
                    return;

                _newZipCode = Utils.Action.FormatCep(value);
                OnPropertyChanged();

                // Dispara validação automaticamente
                if (Utils.Action.IsCepCompleto(_newZipCode))
                    _ = ValidarEnderecoSeNecessarioAsync();
            }
        }
        public string NewCountry { get; set; } = string.Empty;
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
        public ICommand ValidateCepCommand { get; }
        public CustomerPageModel(IMediator mediator, IValidator<CreateCustomerRequest> validator, CepService cepService)
        {
            _mediator = mediator;
            _validator = validator;
            _cepService = cepService;
            SaveCommand = new AsyncRelayCommand(SaveAsync);
            AddAddressCommand = new RelayCommand(AddAddress);
            ValidateCepCommand = new AsyncRelayCommand(ValidarEnderecoAsync);

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
                AddAddress();

                var customerRequest = CustomerMapping.ToRequest(this);

                var result = _validator.Validate(customerRequest);

                if (!result.IsValid)
                {
                    throw new System.ComponentModel.DataAnnotations.ValidationException(result.Errors[0].ErrorMessage);
                }

                var customerResult = await _mediator.Send(new CreateCustomerCommand(customerRequest));
                if (!customerResult)
                {
                    ErrorMessage = "Failed to save Customer.";
                    return;
                }

                CleanFields();
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Unexpected error: {ex.Message}";
            }
        }        
        public async Task ValidarEnderecoAsync()
        {
            try
            {
                var endereco = await _cepService.ObterEnderecoPorCepAsync(NewZipCode);

                if (endereco == null)
                    throw new System.ComponentModel.DataAnnotations.ValidationException("CEP inválido ou não encontrado.");
                                
                NewStreet = endereco.logradouro;
                NewDistrict = endereco.bairro;
                NewCity = endereco.localidade;
                NewState = endereco.estado;
                NewCountry = "Brasil";
                OnPropertyChanged(nameof(NewStreet));
                OnPropertyChanged(nameof(NewDistrict));
                OnPropertyChanged(nameof(NewCity));
                OnPropertyChanged(nameof(NewState));
                OnPropertyChanged(nameof(NewCountry));
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Unexpected error: {ex.Message}";
            }
        }        
        private async Task ValidarEnderecoSeNecessarioAsync()
        {
            if (_isValidatingCep)
                return;

            _isValidatingCep = true;

            await ValidarEnderecoAsync();

            _isValidatingCep = false;
        }
        public void AddAddress()
        {
            if (string.IsNullOrWhiteSpace(NewStreet) || string.IsNullOrWhiteSpace(NewCity) || string.IsNullOrWhiteSpace(NewZipCode))
            {
                ErrorMessage = "Please fill in all address fields.";
                return;
            }

            if (OptionsAddressType.Count == 0 || !OptionsAddressType.Any(o => o.IsSelected))
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
                        Number = NewNumber,
                        Complement = NewComplement,
                        District = NewDistrict,
                        City = NewCity,
                        State = NewState,
                        ZipCode = NewZipCode,
                        Country = NewCountry,
                        AddressType = option.NameAddressType
                    };
                    Addresses.Add(newAddress);

                    break;
                }
            }

            CleanFieldsAddress();

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
        private void CleanFieldsAddress()
        {
            NewStreet = string.Empty;
            NewNumber = string.Empty;
            NewComplement = string.Empty;
            NewDistrict = string.Empty;
            NewCity = string.Empty;
            NewState = string.Empty;
            NewZipCode = string.Empty;
            NewCountry = string.Empty;
            OnPropertyChanged(nameof(Addresses));
            OnPropertyChanged(nameof(NewStreet));
            OnPropertyChanged(nameof(NewNumber));
            OnPropertyChanged(nameof(NewComplement));
            OnPropertyChanged(nameof(NewCity));
            OnPropertyChanged(nameof(NewState));
            OnPropertyChanged(nameof(NewZipCode));
            OnPropertyChanged(nameof(NewCountry));
            ErrorMessage = null; // Limpar mensagem de erro
        }

    }
}
