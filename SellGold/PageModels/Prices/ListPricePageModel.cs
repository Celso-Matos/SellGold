using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using SellGold.Application.Prices.Queries;
using SellGold.Contracts.DTOs.Prices.Responses;
using System.ComponentModel.DataAnnotations;

namespace SellGold.PageModels.Prices
{
    public partial class ListPricePageModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private List<PriceResponse> price = new();
        public List<PriceResponse> Prices
        {
            get => price;
            set => SetProperty(ref price, value);
        }
        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }
        public IAsyncRelayCommand LoadPricesCommand { get; }

        public ListPricePageModel(IMediator mediator)
        {
            _mediator = mediator;
            LoadPricesCommand = new AsyncRelayCommand(LoadPricesAsync);
        }

        public async Task LoadPricesAsync()
        {
            try
            {
                var prices = await _mediator.Send(new ListPriceQuery());
                Prices = prices;
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
