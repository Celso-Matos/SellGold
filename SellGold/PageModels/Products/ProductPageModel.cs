using CommunityToolkit.Mvvm.Input;
using SellGold.Application.Products.Commands;
using SellGold.Mappings.Products;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SellGold.PageModels.Products
{
    public class ProductPageModel : BindableObject
    {
        private readonly IMediator _mediator;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string BarcodeType { get; set; } = string.Empty;

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        // Command de Ação
        public IAsyncRelayCommand SaveCommand { get; }
        public ProductPageModel(IMediator mediator)
        {
            _mediator = mediator;
            SaveCommand = new AsyncRelayCommand(SaveAsync);

        }
        private async Task SaveAsync()
        {
            try
            {
                var productRequest = ProductMapping.ToRequest(this);
                var result = await _mediator.Send(new CreateProductCommand(productRequest));
                if (!result)
                {
                    ErrorMessage = "Failed to save product.";
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
            Name = string.Empty;
            Description = string.Empty;
            IsActive = false;
            Barcode = string.Empty;
            BarcodeType = string.Empty;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(IsActive));
            OnPropertyChanged(nameof(Barcode));
            OnPropertyChanged(nameof(BarcodeType));
        }
    }
}
