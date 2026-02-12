using AutoMapper;
using MediatR;
using SellGold.Prices.Application.Contracts.DTOs.Responses;
using SellGold.Prices.Application.Interfaces.Repositories;
using SellGold.Prices.Application.Queries.GraphQL;

namespace SellGold.Prices.Application.Handlers.GraphQL
{
    public class GetAllPricesGraphQLHandler : IRequestHandler<GetAllPricesGraphQLQuery, List<PriceResponse>>
    {
        private readonly IPricesRepository _repository;
        private readonly IMapper _mapper;
        public GetAllPricesGraphQLHandler(IPricesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<PriceResponse>> Handle(GetAllPricesGraphQLQuery query, CancellationToken cancellationToken)
        {
            var prices = await _repository.GetAllAsync();
            return _mapper.Map<List<PriceResponse>>(prices);
        }    
    }
}
