using MediatR;
using SellGold.Stock.Application.Contracts.DTOs.Requests;

namespace SellGold.Stock.Application.Commands
{
    public record CreateStockCommand(StockRequest CreateStockRequest) : IRequest<StockRequest>;
}
