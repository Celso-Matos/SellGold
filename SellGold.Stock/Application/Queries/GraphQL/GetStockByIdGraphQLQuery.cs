using MediatR;
using SellGold.Stock.Application.Contracts.DTOs.Responses;

namespace SellGold.Stock.Application.Queries.GraphQL
{
    public record GetStockByIdGraphQLQuery(Guid StockProductId) : IRequest<StockProductResponse>;
}
