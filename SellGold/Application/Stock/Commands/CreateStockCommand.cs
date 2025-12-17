using MediatR;
using SellGold.Contracts.DTOs.Stock.Requests;

namespace SellGold.Application.Stock.Commands
{
    public record CreateStockCommand(CreateStockRequest CreateStockRequest) : IRequest<bool>;
}
