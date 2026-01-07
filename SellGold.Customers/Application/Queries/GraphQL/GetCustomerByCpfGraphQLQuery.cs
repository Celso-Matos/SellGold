using MediatR;
using SellGold.Customers.Application.Contracts.DTOs.Responses;

namespace SellGold.Customers.Application.Queries.GraphQL
{
    public class GetCustomerByCpfGraphQLQuery : IRequest<CustomerResponse>
    {
        public string Cpf { get; }
        public GetCustomerByCpfGraphQLQuery(string cpf, CancellationToken cancellationToken = default)
        {
            Cpf = cpf;
        }    
    }
}
