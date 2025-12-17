using MediatR;
using SellGold.Contracts.DTOs.Prices.Responses;

namespace SellGold.Application.Prices.Queries
{
    public record ListPriceQuery() : IRequest<List<PriceResponse>>;
}
