using CommunityToolkit.Mvvm.Input;
using MediatR;
using SellGold.Application.Prices.Commands;
using SellGold.Application.Prices.Queries;
using SellGold.Application.Products.Queries;
using SellGold.Contracts.DTOs.Prices.Requests;
using SellGold.Contracts.DTOs.Prices.Responses;
using SellGold.Contracts.DTOs.Products.Responses;
using SellGold.Mappings.Prices;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Windows.Input;

namespace SellGold.PageModels.Prices
{
    public class PricePageModel : BindableObject
    {
        private readonly IMediator _mediator;

        private decimal _basePriceAmount;
        public decimal NewBasePriceAmount
        {
            get => _basePriceAmount;
            set { _basePriceAmount = value; OnPropertyChanged(); }
        }

        private string _newBasePriceCurrency;
        public string NewBasePriceCurrency
        {
            get => string.IsNullOrEmpty(_newBasePriceCurrency) ? "BRL" : _newBasePriceCurrency;
            set
            {
                _newBasePriceCurrency = value;
                OnPropertyChanged();
            }
        }

        private bool _isActive = true;
        public bool NewIsActive
        {
            get => _isActive;
            set { _isActive = value; OnPropertyChanged(); }
        }

        private ProductResponse _selectedPriceProducts;
        public ProductResponse SelectedPriceProducts
        {
            get => _selectedPriceProducts;
            set
            {
                _selectedPriceProducts = value;
                if(value != null)
                {
                    NewBasePriceAmount = (decimal)value.BasePriceAmount;
                    NewBasePriceCurrency = value.BasePriceCurrency ?? "BRL";
                    NewIsActive = value.IsActive;
                }
                OnPropertyChanged();
            }
        }

        // Produtos e Preços
        public string NameProductSearchBar { get; set; } = string.Empty;
        public ObservableCollection<ProductResponse> ProductsWithPrice { get; set; } = new();
        public ObservableCollection<PriceProductsResponse> NewPricesProducts { get; set; } = new();
        public DateTime NewEffectiveDate { get; set; } = DateTime.Today;
        public DateTime NewExpirationDate { get; set; } = DateTime.Today.AddDays(30);
        public ObservableCollection<PriceDiscountRequest> NewDiscounts { get; set; } = new();
        public ObservableCollection<PricePolicyRequest> NewPolicies { get; set; } = new();
        public ObservableCollection<PriceTaxRequest> NewTaxes { get; set; } = new();

        private bool _isEditing;
        public bool IsEditing
        {
            get => _isEditing;
            set
            {
                _isEditing = value;
                OnPropertyChanged();
            }
        }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }
        public IAsyncRelayCommand SearchProductsCommand { get; }
        public IAsyncRelayCommand SaveCommand { get; }
        public ICommand EditPriceProductsCommand { get; }

        public PricePageModel(IMediator mediator)
        {
            _mediator = mediator;
            SearchProductsCommand = new AsyncRelayCommand(SearchProductsAsync);
            SaveCommand = new AsyncRelayCommand(SaveAsync);
            EditPriceProductsCommand = new Command<ProductResponse>(EditPriceProducts);
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
        // Refatoração para reduzir a complexidade cognitiva do método SearchProductsAsync
        public async Task SearchProductsAsync()
        {
            var products = await _mediator.Send(new ListGraphQLProductNameQuery(NameProductSearchBar));

            if (products == null || !products.Any())
                return;

            ProductsWithPrice.Clear();

            foreach (var product in products.Where(p => p.Success))
            {
                await AddProductWithPriceAsync(product);
            }
        }

        private async Task AddProductWithPriceAsync(ProductResponse product)
        {
            var pricesProducts = await _mediator.Send(new ListGraphQLPriceProductsByIdQuery(product.ProductId));

            if (pricesProducts == null || !pricesProducts.Any())
            {
                ProductsWithPrice.Add(product);
                return;
            }

            foreach (var priceProduct in pricesProducts)
            {
                if (!priceProduct.Success)
                {
                    ProductsWithPrice.Add(product);
                    continue;
                }

                var productPriceDetails = await _mediator.Send(new ListGraphQLPriceByIdQuery(pricesProducts.FirstOrDefault()?.PriceId));

                if (productPriceDetails != null && productPriceDetails.Any())
                {
                    product.BasePriceAmount = productPriceDetails.FirstOrDefault()?.BasePriceAmount ?? 0;
                }

                ProductsWithPrice.Add(product);
            }
        }

        public void EditPriceProducts(ProductResponse product)
        {
            SelectedPriceProducts = product;
            IsEditing = true;

        }
        private void CleanFields()
        {
            NewBasePriceAmount = 0;
            NewBasePriceCurrency = "BRL";
            NewIsActive = true;
            NewDiscounts.Clear();
            NewPolicies.Clear();    
            NewTaxes.Clear();

            OnPropertyChanged(nameof(NewBasePriceAmount));
            OnPropertyChanged(nameof(NewBasePriceCurrency));
            OnPropertyChanged(nameof(NewIsActive));
            OnPropertyChanged(nameof(NewDiscounts));
            OnPropertyChanged(nameof(NewPolicies));
            OnPropertyChanged(nameof(NewTaxes));
        }

    }
}
