using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using SellGold.Application.Products.Queries;
using SellGold.Contracts.DTOs.Products.Responses;
using System.ComponentModel.DataAnnotations;

namespace SellGold.PageModels.Products
{
    public partial class ListProductPageModel : ObservableObject
    {
        private readonly IMediator _mediator;

        private List<ProductResponse> product = new();
        public List<ProductResponse> Products
        {
            get => product;
            set => SetProperty(ref product, value);
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
                var products = await _mediator.Send(new ListProductQuery());
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
