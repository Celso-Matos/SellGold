using MediatR;
using SellGold.Prices.Application.Contracts.DTOs.Requests;

namespace SellGold.Prices.Application.Commands
{
    public record CreatePriceCommand(PriceRequest CreatePriceRequest) : IRequest<PriceRequest>;
}
