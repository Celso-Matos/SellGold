using MediatR;
using SellGold.Application.Payments.Queries;
using SellGold.Contracts.DTOs.Payments.Responses;
using SellGold.GraphQL.Payments.Services;

namespace SellGold.Application.Payments.Handlers
{
    public class ListGraphQLPaymentCpfHandler : IRequestHandler<ListGraphQLPaymentCpfQuery, CustomerResponse>
    {
        private readonly ListPaymentCpfGraphQLService _service;
        public ListGraphQLPaymentCpfHandler(ListPaymentCpfGraphQLService service)
        {
            _service = service;
        }
        public async Task<CustomerResponse> Handle(ListGraphQLPaymentCpfQuery request, CancellationToken cancellationToken)
        {
            var customer = await _service.GetCustomerGraphQLByCpfAsync((request.Document ?? string.Empty), cancellationToken);
            return customer ?? new CustomerResponse();
        }
    }    
}
