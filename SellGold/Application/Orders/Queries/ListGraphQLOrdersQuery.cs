using MediatR;
using SellGold.Contracts.DTOs.Orders.Responses;

namespace SellGold.Application.Orders.Queries
{
    public record ListGraphQLOrdersQuery() : IRequest<List<OrderResponse>>;
}
