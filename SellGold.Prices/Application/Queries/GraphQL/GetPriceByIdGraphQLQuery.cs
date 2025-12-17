using MediatR;
using SellGold.Prices.Application.Contracts.DTOs.Responses;

namespace SellGold.Prices.Application.Queries.GraphQL
{
    public record GetPriceByIdGraphQLQuery(Guid PriceId) : IRequest<PriceResponse>;
}
