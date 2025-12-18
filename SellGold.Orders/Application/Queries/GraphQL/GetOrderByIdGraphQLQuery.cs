using MediatR;
using SellGold.Orders.Application.Contracts.DTOs.Responses;

namespace SellGold.Orders.Application.Queries.GraphQL
{
    public record GetOrderByIdGraphQLQuery(Guid OrderId) : IRequest<OrderResponse>;
}
