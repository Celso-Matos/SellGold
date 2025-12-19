using MediatR;
using SellGold.Contracts.DTOs.Prices.Responses;

namespace SellGold.Application.Prices.Queries
{
    public record ListGraphQLPricesQuery() : IRequest<List<PriceResponse>>;
}
