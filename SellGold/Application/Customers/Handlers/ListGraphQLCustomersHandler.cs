using MediatR;
using SellGold.Application.Customers.Queries;
using SellGold.Contracts.DTOs.Customers.Responses;
using SellGold.GraphQL.Customers.Services;

namespace SellGold.Application.Customers.Handlers
{
    public class ListGraphQLCustomersHandler : IRequestHandler<ListGraphQLCustomersQuery, List<CustomerResponse>>
    {
        private readonly ListCustomerGraphQLService _service;
        public ListGraphQLCustomersHandler(ListCustomerGraphQLService service)
        {
            _service = service;
        }
        public async Task<List<CustomerResponse>> Handle(ListGraphQLCustomersQuery query, CancellationToken cancellationToken)
        {
            var customers = await _service.GetAllCustomersGraphQLAsync(query.Cpf, cancellationToken);
            return customers ?? new List<CustomerResponse>();
        }
    }
}
