using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using SellGold.Application.Customers.Queries;
using SellGold.Contracts.DTOs.Customers.Responses;
using System.ComponentModel.DataAnnotations;

namespace SellGold.PageModels.Customers
{
    public partial class ListCustomerPageModel : ObservableObject
    {
        private readonly IMediator _mediator;

        private List<CustomerResponse> _customers = new();

        public List<CustomerResponse> Customers
        {
            get => _customers;
            set => SetProperty(ref _customers, value);
        }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public IAsyncRelayCommand LoadCustomersCommand {  get; }

        public ListCustomerPageModel(IMediator mediator) 
        { 
            _mediator = mediator;
            LoadCustomersCommand = new AsyncRelayCommand(LoadCustomersAsync);
        
        }
        public async Task LoadCustomersAsync()
        {
            try
            {
                var customers = await _mediator.Send(new ListGraphQLCustomersQuery());
                Customers = customers;
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

    }
}
