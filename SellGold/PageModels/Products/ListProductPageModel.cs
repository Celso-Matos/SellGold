using MediatR;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SellGold.Application.Products.Queries;
using SellGold.Contracts.DTOs.Products.Responses;
using System.ComponentModel.DataAnnotations;

namespace SellGold.PageModels.Products
{
    public partial class ListProductPageModel : ObservableObject
    {
        private readonly IMediator _mediator;

        private List<ProductResponse> _products = new();
        public List<ProductResponse> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public IAsyncRelayCommand LoadProductsCommand { get; }


        public ListProductPageModel(IMediator mediator)
        {
            _mediator = mediator;
            LoadProductsCommand = new AsyncRelayCommand(LoadProductsAsync);

        }

        public async Task LoadProductsAsync()
        {
            try
            {
                var products = await _mediator.Send(new ListGraphQLProductsQuery());
                Products = products;
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
