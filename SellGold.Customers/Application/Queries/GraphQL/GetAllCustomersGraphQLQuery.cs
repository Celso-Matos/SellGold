using MediatR;
using SellGold.Customers.Application.Contracts.DTOs.Responses;

namespace SellGold.Customers.Application.Queries.GraphQL
{
    public class GetAllCustomersGraphQLQuery: IRequest<List<CustomerResponse>>
    {
        public string? Cpf { get; }

        public GetAllCustomersGraphQLQuery(string? cpf = null, CancellationToken cancellationToken = default)
        {
            Cpf = cpf;
        }
    }
}
