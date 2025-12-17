using MediatR;
using SellGold.Application.Suppliers.Commands;
using SellGold.Services.Suppliers;
using System.ComponentModel.DataAnnotations;

namespace SellGold.Application.Suppliers.Handlers
{
    public class CreateSupplierHandler : IRequestHandler<CreateSupplierCommand, bool>
    {
        private readonly SupplierService _service;
        public CreateSupplierHandler(SupplierService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = request.CreateSupplierRequest;
            var context = new ValidationContext(supplier);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(supplier, context, results, true))
            {
                var errors = string.Join("\n", results.Select(r => r.ErrorMessage));
                throw new ValidationException(errors);
            }
            return await _service.AddSupplierAsync(supplier);
        }
    } 
}
