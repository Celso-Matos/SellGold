using CommunityToolkit.Mvvm.Input;
using MediatR;
using SellGold.Application.Prices.Commands;
using SellGold.Application.Products.Queries;
using SellGold.Contracts.DTOs.Prices.Requests;
using SellGold.Contracts.DTOs.Products.Responses;
using SellGold.Mappings.Prices;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace SellGold.PageModels.Prices
{
    public class PricePageModel : BindableObject
    {
        private readonly IMediator _mediator;

        private decimal _basePriceAmount;
        public decimal BasePriceAmount
        {
            get => _basePriceAmount;
            set { _basePriceAmount = value; OnPropertyChanged(); }
        }

        private string _basePriceCurrency = string.Empty;
        public string BasePriceCurrency
        {
            get => _basePriceCurrency;
            set { _basePriceCurrency = value; OnPropertyChanged(); }
        }

        private bool _isActive = true;
        public bool IsActive
        {
            get => _isActive;
            set { _isActive = value; OnPropertyChanged(); }
        }


        // Produtos
        public string NameProductSearchBar { get; set; } = string.Empty;
        public ObservableCollection<ProductResponse> SearchResults { get; set; } = new();
        public ObservableCollection<ProductResponse> SelectedProducts { get; set; } = new();
        public DateTime EffectiveDate { get; set; } = DateTime.Today;
        public DateTime ExpirationDate { get; set; } = DateTime.Today.AddDays(30);

        public ObservableCollection<PriceDiscountRequest> Discounts { get; set; } = new();
        public ObservableCollection<PricePolicyRequest> Policies { get; set; } = new();
        public ObservableCollection<PriceTaxRequest> Taxes { get; set; } = new();


        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }
        public IAsyncRelayCommand SearchProductsCommand { get; }

        public IAsyncRelayCommand SaveCommand { get; }

        public PricePageModel(IMediator mediator)
        {
            _mediator = mediator;
            SearchProductsCommand = new AsyncRelayCommand(SearchProductsAsync);
            SaveCommand = new AsyncRelayCommand(SaveAsync);
        }

        private async Task SaveAsync()
        {
            try
            {
                var priceRequest = PriceMapping.ToRequest(this);
                var result = await _mediator.Send(new CreatePriceCommand(priceRequest));
                if (!result)
                {
                    ErrorMessage = "Failed to save price.";
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

        public async Task SearchProductsAsync()
        {
            if (string.IsNullOrWhiteSpace(NameProductSearchBar))
            {
                SearchResults.Clear();
                
            }

            var products = await _mediator.Send(new ListGraphQLProductNameQuery(NameProductSearchBar));

            SearchResults.Clear();
            if (products != null && products.Any())
            {
                foreach (var p in products)
                    SearchResults.Add(p);

            }            
        }
        private void CleanFields()
        {
            BasePriceAmount = 0;
            BasePriceCurrency = "BRL";
            IsActive = true;
            Discounts.Clear();
            Policies.Clear();
            Taxes.Clear();

            OnPropertyChanged(nameof(BasePriceAmount));
            OnPropertyChanged(nameof(BasePriceCurrency));
            OnPropertyChanged(nameof(IsActive));
            OnPropertyChanged(nameof(Discounts));
            OnPropertyChanged(nameof(Policies));
            OnPropertyChanged(nameof(Taxes));
        }

    }
}
