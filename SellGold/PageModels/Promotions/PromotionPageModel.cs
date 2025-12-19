using CommunityToolkit.Mvvm.Input;
using SellGold.Application.Promotions.Commands;
using System.ComponentModel.DataAnnotations;
using MediatR;
using SellGold.Mappings.Promotions;

namespace SellGold.PageModels.Promotions
{
    public class PromotionPageModel : BindableObject
    {
        private readonly IMediator _mediator;
        public string Name { get; set; } = string.Empty;
        public System.DateTimeOffset StartDate { get; set; }
        public System.DateTimeOffset EndDate { get; set; }
        public double DiscountPercentage { get; set; }
        public string Description { get; set; } = string.Empty;

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        // Command de Ação
        public IAsyncRelayCommand SaveCommand { get; }

        public PromotionPageModel(IMediator mediator)
        {
            _mediator = mediator;
            SaveCommand = new AsyncRelayCommand(SaveAsync);
        }

        private async Task SaveAsync()
        {
            try
            {
                var promotionRequest = PromotionMapping.ToRequest(this);
                var result = await _mediator.Send(new CreatePromotionCommand(promotionRequest));
                if (!result)
                {
                    ErrorMessage = "Failed to save promotion.";
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
            Name = String.Empty;
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;
            DiscountPercentage = 0;
            Description = String.Empty;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(StartDate));
            OnPropertyChanged(nameof(EndDate));
            OnPropertyChanged(nameof(DiscountPercentage));
            OnPropertyChanged(nameof(Description));
        
        }
    }
}
