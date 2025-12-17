using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using SellGold.Application.Stock.Queries;
using SellGold.Contracts.DTOs.Stock.Responses;
using System.ComponentModel.DataAnnotations;

namespace SellGold.PageModels.Stock
{
    public partial class ListStockPageModel : ObservableObject
    {
        private readonly IMediator _mediator;

        private List<StockResponse> stock = new();
        public List<StockResponse> Stocks
        {
            get => stock;
            set => SetProperty(ref stock, value);
        }
        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }
        public IAsyncRelayCommand LoadStocksCommand { get; }
        public ListStockPageModel(IMediator mediator)
        {
            _mediator = mediator;
            LoadStocksCommand = new AsyncRelayCommand(LoadStockAsync);
        }
        public async Task LoadStockAsync()
        {
            try
            {
                var stocks = await _mediator.Send(new ListStockQuery());
                Stocks = stocks;
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
