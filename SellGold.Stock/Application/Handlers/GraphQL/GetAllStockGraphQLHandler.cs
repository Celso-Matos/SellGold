using MediatR;
using SellGold.Stock.Application.Contracts.DTOs.Responses;
using SellGold.Stock.Application.Contracts.Mappers;
using SellGold.Stock.Application.Interfaces.Repositories;
using SellGold.Stock.Application.Queries.GraphQL;

namespace SellGold.Stock.Application.Handlers.GraphQL
{
    public class GetAllStockGraphQLHandler : IRequestHandler<GetAllStockGraphQLQuery, List<StockProductResponse>>
    {
        private readonly IStockRepository _repository;
        public GetAllStockGraphQLHandler(IStockRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<StockProductResponse>> Handle(GetAllStockGraphQLQuery query, CancellationToken cancellationToken)
        {
            var stockProducts = await _repository.GetAllAsync();
            return StockProductMapper.ToResponseList(stockProducts);
        }

    }
}
