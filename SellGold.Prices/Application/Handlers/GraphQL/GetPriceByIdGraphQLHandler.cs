using MediatR;
using SellGold.Prices.Application.Contracts.DTOs.Responses;
using SellGold.Prices.Application.Contracts.Mappers;
using SellGold.Prices.Application.Interfaces.Repositories;
using SellGold.Prices.Application.Queries.GraphQL;

namespace SellGold.Prices.Application.Handlers.GraphQL
{
    public class GetPriceByIdGraphQLHandler : IRequestHandler<GetPriceByIdGraphQLQuery, PriceResponse>
    {
        private readonly IPricesRepository _repository;
        public GetPriceByIdGraphQLHandler(IPricesRepository repository)
        {
            _repository = repository;
        }
        public async Task<PriceResponse> Handle(GetPriceByIdGraphQLQuery query, CancellationToken cancellationToken)
        {
            var price = await _repository.GetByIdAsync(query.PriceId);
            return price == null ? null! : PriceMapper.ToResponse(price);
        }    
    }
}
