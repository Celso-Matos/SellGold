using MediatR;
using SellGold.Prices.Application.Contracts.DTOs.Responses;

namespace SellGold.Prices.Application.Queries.GraphQL
{
    public record GetAllPricesGraphQLQuery() : IRequest<List<PriceResponse>>;
}
