using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediatR;
using SellGold.Application.Suppliers.Queries;
using SellGold.Contracts.DTOs.Suppliers.Responses;
using System.ComponentModel.DataAnnotations;

namespace SellGold.PageModels.Suppliers
{
    public partial class ListSupplierPageModel : ObservableObject
    {
        private readonly IMediator _mediator;

        private List<SupplierResponse> supplier = new();
        public List<SupplierResponse> Suppiers
        {
            get => supplier;
            set => SetProperty(ref supplier, value);
        }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }
        public IAsyncRelayCommand LoadSuppliersCommand { get; }

        public ListSupplierPageModel(IMediator mediator)
        {
            _mediator = mediator;
            LoadSuppliersCommand = new AsyncRelayCommand(LoadSuppliersAsync);
        }

        public async Task LoadSuppliersAsync()
        {
            try
            {
                var suppliers = await _mediator.Send(new ListGraphQLSuppliersQuery());
                Suppiers = suppliers;
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
