using MediatR;
using SellGold.Customers.Application.Contracts.DTOs.Responses;

namespace SellGold.Customers.Application.Queries.GraphQL
{
    public record GetAllCustomersGraphQLQuery() : IRequest<List<CustomerResponse>>;
}
