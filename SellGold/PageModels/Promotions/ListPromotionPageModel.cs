using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using SellGold.Application.Promotions.Queries;
using SellGold.Contracts.DTOs.Promotions.Responses;
using System.ComponentModel.DataAnnotations;

namespace SellGold.PageModels.Promotions
{
    public partial class ListPromotionPageModel : ObservableObject
    {
        private readonly IMediator _mediator;
        
        private List<PromotionResponse> _promotions = new();

        public List<PromotionResponse> Promotions
        {
            get => _promotions;
            set => SetProperty(ref _promotions, value);
        }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public IAsyncRelayCommand LoadPromotionsCommand { get; }

        public ListPromotionPageModel(IMediator mediator)
        {
            _mediator = mediator;            
            LoadPromotionsCommand = new AsyncRelayCommand(LoadPromotionsAsync);
        }

        public async Task LoadPromotionsAsync()
        {
            try
            {
                var promotions = await _mediator.Send(new ListGraphQLPromotionsQuery());
                Promotions = promotions;
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
