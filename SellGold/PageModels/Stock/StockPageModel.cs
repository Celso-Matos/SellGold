using CommunityToolkit.Mvvm.Input;
using SellGold.Application.Stock.Commands;
using SellGold.Mappings.Stock;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SellGold.PageModels.Stock
{
    public class StockPageModel : BindableObject
    {
        private readonly IMediator _mediator;

        // Propriedades ligadas aos campos da tela
        public Guid StockProductId { get; set; } = Guid.Empty;
        public Guid ProductId { get; set; } = Guid.Empty;
        public int CurrentQuantity { get; set; }
        public DateTime DateMovement { get; set; } = DateTime.Now;
        public int AmountMovement { get; set; }
        public int MovementType { get; set; }
        public string? Observation { get; set; }
        public string StockLocationName { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string? Complement { get; set; }
        public string District { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }
        // Command de Ação
        public IAsyncRelayCommand SaveCommand { get; }
        public StockPageModel(IMediator mediator)
        {
            _mediator = mediator;
            SaveCommand = new AsyncRelayCommand(SaveAsync);
        }
        private async Task SaveAsync()
        {
            try
            {
                var stockRequest = StockMapping.ToRequest(this);
                var result = await _mediator.Send(new CreateStockCommand(stockRequest));
                if (!result)
                {
                    ErrorMessage = "Failed to save stock.";
                    return;
                }
                // Limpa os campos
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
            StockProductId = Guid.Empty;
            ProductId = Guid.Empty;
            CurrentQuantity = 0;
            DateMovement = DateTime.Now;
            AmountMovement = 0;
            MovementType = 0;
            Observation = string.Empty;
            StockLocationName = string.Empty;
            Street = string.Empty;
            Number = string.Empty;
            Complement = string.Empty;
            District = string.Empty;
            City = string.Empty;
            State = string.Empty;
            ZipCode = string.Empty;
            Country = string.Empty;
            ErrorMessage = string.Empty;

        }
    }
}