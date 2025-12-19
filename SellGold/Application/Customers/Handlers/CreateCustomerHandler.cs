using MediatR;
using SellGold.Application.Customers.Commands;
using SellGold.Services.Customers;
using System.ComponentModel.DataAnnotations;

namespace SellGold.Application.Customers.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly CustomerService _service;

        public CreateCustomerHandler(CustomerService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var Customer = request.createCustomerRequest;
            var context = new ValidationContext(Customer);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(Customer, context, results, true))
            {
                var errors = string.Join("\n", results.Select(r => r.ErrorMessage));
                throw new ValidationException(errors);
            }
            return await _service.AddCustomerAsync(Customer, cancellationToken);
        }
    }
}
