using MediatR;
using SellGold.Application.Orders.Commands;
using SellGold.Services.Orders;
using System.ComponentModel.DataAnnotations;

namespace SellGold.Application.Orders.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly OrderService _service;

        public CreateOrderHandler(OrderService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(CreateOrderCommand request,  CancellationToken cancellationToken)
        {
            var order = request.createOrderRequest;
            var context = new ValidationContext(order);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(order, context, results, true))
            {
                var errors = string.Join("\n", results.Select(r => r.ErrorMessage));
                throw new ValidationException(errors);
            }
            return await _service.AddOrderAsync(order, cancellationToken);
        }
    }
}
