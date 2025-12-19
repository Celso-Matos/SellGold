using MediatR;
using SellGold.Contracts.DTOs.Customers.Responses;

namespace SellGold.Application.Customers.Queries
{
    public record ListGraphQLCustomersQuery() : IRequest<List<CustomerResponse>>;
}
