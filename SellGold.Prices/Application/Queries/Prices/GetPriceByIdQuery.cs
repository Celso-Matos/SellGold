using MediatR;
using SellGold.Prices.Application.Contracts.DTOs.Responses;

namespace SellGold.Prices.Application.Queries.Prices
{
    public record GetPriceByIdQuery(Guid PriceId) : IRequest<PriceResponse>;
}
