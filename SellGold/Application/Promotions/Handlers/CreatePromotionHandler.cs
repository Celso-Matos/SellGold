using MediatR;
using SellGold.Application.Promotions.Commands;
using SellGold.Services.Promotions;
using System.ComponentModel.DataAnnotations;

namespace SellGold.Application.Promotions.Handlers
{
    public class CreatePromotionHandler : IRequestHandler<CreatePromotionCommand, bool>
    {
        private readonly PromotionService _service;

        public CreatePromotionHandler(PromotionService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var Promotion = request.createPromotionRequest;
            var context = new ValidationContext(Promotion);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(Promotion, context, results, true))
            {
                var errors = string.Join("\n", results.Select(r => r.ErrorMessage));
                throw new ValidationException(errors);
            }
            return await _service.AddPromotionAsync(Promotion);
        }
    }
}
