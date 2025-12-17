using MediatR;
using SellGold.Application.Products.Commands;
using SellGold.Services.Products;
using System.ComponentModel.DataAnnotations;

namespace SellGold.Application.Products.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly ProductService _service;

        public CreateProductHandler(ProductService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.CreateProductRequest;
            var context = new ValidationContext(product);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(product, context, results, true))
            {
                var errors = string.Join("\n", results.Select(r => r.ErrorMessage));
                throw new ValidationException(errors);
            }
            return await _service.AddProductAsync(product);
        }
    }
}
