using CommunityToolkit.Mvvm.Input;
using SellGold.Application.Prices.Commands;
using SellGold.Mappings.Prices;
using System.ComponentModel.DataAnnotations;
using SellGold.Contracts.DTOs.Prices.Requests;
using MediatR;

namespace SellGold.PageModels.Prices
{
    public class PricePageModel : BindableObject
    {
        private readonly IMediator _mediator;

        public double BasePriceAmount { get; set; }
        public string BasePriceCurrency { get; set; } = "BRL";
        public bool IsActive { get; set; } = true;
        public ICollection<PriceDiscountRequest> Discounts { get; set; } = new List<PriceDiscountRequest>();
        public ICollection<PricePolicyRequest> Policies { get; set; } = new List<PricePolicyRequest>();
        public ICollection<PriceTaxRequest> Taxes { get; set; } = new List<PriceTaxRequest>();

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public IAsyncRelayCommand SaveCommand { get; }

        public PricePageModel(IMediator mediator)
        {
            _mediator = mediator;
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
