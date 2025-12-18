using MediatR;
using SellGold.Orders.Application.Contracts.DTOs.Responses;

namespace SellGold.Orders.Application.Queries.GraphQL
{
    public class GetAllOrderGraphQLQuery() : IRequest<List<OrderResponse>>;
}
