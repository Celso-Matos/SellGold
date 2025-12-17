using MediatR;
using SellGold.Contracts.DTOs.Stock.Responses;

namespace SellGold.Application.Stock.Queries
{
    public record ListStockQuery() : IRequest<List<StockResponse>>;
}
