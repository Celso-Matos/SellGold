using CommunityToolkit.Mvvm.Input;
using SellGold.Application.Orders.Commands;
using SellGold.Mappings.Orders;
using System.ComponentModel.DataAnnotations;
using SellGold.Contracts.DTOs.Orders.Requests;
using MediatR;

namespace SellGold.PageModels.Orders
{
    public class OrderPageModel : BindableObject
    {
        private readonly IMediator _mediator;

        public Guid CustomerId { get; set; }
        public ICollection<CreateOrderItemRequest> Items { get; set; } = new List<CreateOrderItemRequest>();
        public DateTimeOffset? OrderDate { get; set; }

        private string? _errorMessage;
        public string? ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public IAsyncRelayCommand SaveCommand { get; }

        public OrderPageModel(IMediator mediator)
        {
            _mediator = mediator;
            SaveCommand = new AsyncRelayCommand(SaveAsync);
        }

        private async Task SaveAsync()
        {
            try
            {
                var orderRequest = OrderMapping.ToRequest(this);
                var result = await _mediator.Send(new CreateOrderCommand(orderRequest));
                if (!result)
                {
                    ErrorMessage = "Failed to save pedido.";
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
            CustomerId = Guid.Empty;
            Items.Clear();
            OrderDate = DateTimeOffset.MinValue;

            OnPropertyChanged(nameof(CustomerId));
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(OrderDate));
        }
    }
}
