using AutoMapper;
using MediatR;
using SellGold.Prices.Application.Contracts.DTOs.Responses;
using SellGold.Prices.Application.Interfaces.Repositories;
using SellGold.Prices.Application.Queries.GraphQL;
using SellGold.Prices.Domain.Entities;

namespace SellGold.Prices.Application.Handlers.GraphQL
{
    public class GetPriceByIdGraphQLHandler : IRequestHandler<GetPriceByIdGraphQLQuery, PriceResponse?>
    {
        private readonly IPricesRepository _repository;
        private readonly IMapper _mapper;
        public GetPriceByIdGraphQLHandler(IPricesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PriceResponse?> Handle(GetPriceByIdGraphQLQuery query, CancellationToken cancellationToken)
        {
            var price = await _repository.GetByIdAsync(query.PriceId);

            if (price == null)
            {
                return new PriceResponse
                {
                    Message = $"Preço com código {query.PriceId} não encontrado.",
                    Success = false
                };
            }

            return _mapper.Map<PriceResponse>(price);
        }    
    }
}
