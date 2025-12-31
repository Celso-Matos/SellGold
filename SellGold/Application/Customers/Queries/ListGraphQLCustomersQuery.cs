using MediatR;
using SellGold.Contracts.DTOs.Customers.Responses;

namespace SellGold.Application.Customers.Queries
{
    public class ListGraphQLCustomersQuery : IRequest<List<CustomerResponse>>
    {
        public string? Cpf { get; }

        public ListGraphQLCustomersQuery(string? cpf = null, CancellationToken cancellationToken = default)
        {
            Cpf = cpf;
        }
    }
}
