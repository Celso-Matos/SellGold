using MediatR;
using SellGold.Stock.Application.Contracts.DTOs.Responses;
using SellGold.Stock.Application.Queries.GraphQL;

namespace SellGold.Stock.API.GraphQL.QueryTypes
{
    public class StockQueryType
    {
        protected StockQueryType() {
        }
        // Query para buscar estoque por ID
        public static async Task<StockProductResponse> GetStockGraphQLByIdAsync(Guid StockProductId,
                                                                    [Service] IMediator mediator)
        {
            return await mediator.Send(new GetStockByIdGraphQLQuery(StockProductId));
        }

        // Query para buscar todos os estoques
        public static async Task<List<StockProductResponse>> GetAllStocksGraphQLAsync(
            [Service] IMediator mediator)
        {
            return await mediator.Send(new GetAllStockGraphQLQuery());
        }
    }
}
