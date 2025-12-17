using MediatR;
using SellGold.Application.Prices.Commands;
using SellGold.Services.Prices;
using System.ComponentModel.DataAnnotations;

namespace SellGold.Application.Prices.Handlers
{
    public class CreatePriceHandler : IRequestHandler<CreatePriceCommand, bool>
    {
        private readonly PriceService _service;
        public CreatePriceHandler(PriceService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
        {
            var price = request.CreatePriceRequest;
            var context = new ValidationContext(price);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(price, context, results, true))
            {
                var errors = string.Join("\n", results.Select(r => r.ErrorMessage));
                throw new ValidationException(errors);
            }
            return await _service.AddPriceAsync(price);
        }
    }    
}
