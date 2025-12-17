using MediatR;
using SellGold.Application.Stock.Commands;
using SellGold.Services.Stock;
using System.ComponentModel.DataAnnotations;

namespace SellGold.Application.Stock.Handlers
{
    public class CreateStockHandler : IRequestHandler<CreateStockCommand, bool>
    {
        private readonly StockService _service;
        public CreateStockHandler(StockService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(CreateStockCommand request, CancellationToken cancellationToken)
        {
            var stock = request.CreateStockRequest;
            var context = new ValidationContext(stock);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(stock, context, results, true))
            {
                var errors = string.Join("\n", results.Select(r => r.ErrorMessage));
                throw new ValidationException(errors);
            }
            return await _service.AddStockAsync(stock);
        }    
    }
}
