using MediatR;
using SellGold.Prices.Application.Contracts.DTOs.Responses;
using SellGold.Prices.Application.Contracts.Mappers;
using SellGold.Prices.Application.Interfaces.Repositories;
using SellGold.Prices.Application.Queries.GraphQL;

namespace SellGold.Prices.Application.Handlers.GraphQL
{
    public class GetAllPricesGraphQLHandler : IRequestHandler<GetAllPricesGraphQLQuery, List<PriceResponse>>
    {
        private readonly IPricesRepository _repository;
        public GetAllPricesGraphQLHandler(IPricesRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<PriceResponse>> Handle(GetAllPricesGraphQLQuery query, CancellationToken cancellationToken)
        {
            var prices = await _repository.GetAllAsync();
            return PriceMapper.ToResponseList(prices);
        }    
    }
}
