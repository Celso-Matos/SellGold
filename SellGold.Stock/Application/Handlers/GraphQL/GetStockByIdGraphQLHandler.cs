using MediatR;
using SellGold.Stock.Application.Contracts.DTOs.Responses;
using SellGold.Stock.Application.Contracts.Mappers;
using SellGold.Stock.Application.Interfaces.Repositories;
using SellGold.Stock.Application.Queries.GraphQL;

namespace SellGold.Stock.Application.Handlers.GraphQL
{
    public class GetStockByIdGraphQLHandler : IRequestHandler<GetStockByIdGraphQLQuery, StockProductResponse>
    {
        private readonly IStockRepository _repository;
        public GetStockByIdGraphQLHandler(IStockRepository repository)
        {
            _repository = repository;
        }
        public async Task<StockProductResponse> Handle(GetStockByIdGraphQLQuery query, CancellationToken cancellationToken)
        {
            var stockProduct = await _repository.GetByIdAsync(query.StockProductId);
            return stockProduct == null ? null! : StockProductMapper.ToResponse(stockProduct);
        }
    
    }
}
