using MediatR;
using SellGold.Stock.Application.Contracts.DTOs.Responses;

namespace SellGold.Stock.Application.Queries.GraphQL
{
    public class GetAllStockGraphQLQuery() : IRequest<List<StockProductResponse>>; 
}
