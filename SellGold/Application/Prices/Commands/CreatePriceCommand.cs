using MediatR;
using SellGold.Contracts.DTOs.Prices.Requests;

namespace SellGold.Application.Prices.Commands
{
    public record CreatePriceCommand(CreatePriceRequest CreatePriceRequest) : IRequest<bool>;
}
