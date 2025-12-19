using MediatR;
using SellGold.Contracts.DTOs.Stock.Responses;

namespace SellGold.Application.Stock.Queries
{
    public record ListGraphQLStockQuery() : IRequest<List<StockResponse>>;
}
