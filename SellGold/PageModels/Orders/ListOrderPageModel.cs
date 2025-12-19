using MediatR;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SellGold.Contracts.DTOs.Orders.Responses;
using System.ComponentModel.DataAnnotations;
using SellGold.Application.Orders.Queries;

namespace SellGold.PageModels.Orders
{
    public partial class ListOrderPageModel : ObservableObject
    {
        private readonly IMediator _mediator;

        private List<OrderResponse> _orders = new();

        public List<OrderResponse> Orders
        { 
            get => _orders;
            set => SetProperty(ref _orders, value);        
        }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public IAsyncRelayCommand LoadOrdersCommand { get; }

        public ListOrderPageModel(IMediator mediator)
        {
            _mediator = mediator;
            LoadOrdersCommand = new AsyncRelayCommand(LoadOrdersAsync);
        }

        public async Task LoadOrdersAsync()
        {
            try
            {
                var orders = await _mediator.Send(new ListGraphQLOrdersQuery());
                Orders = orders;
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
