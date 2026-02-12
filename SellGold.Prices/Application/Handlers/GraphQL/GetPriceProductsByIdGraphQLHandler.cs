using AutoMapper;
using MediatR;
using SellGold.Prices.Application.Contracts.DTOs.Responses;
using SellGold.Prices.Application.Interfaces.Repositories;
using SellGold.Prices.Application.Queries.GraphQL;
using static Confluent.Kafka.ConfigPropertyNames;

namespace SellGold.Prices.Application.Handlers.GraphQL
{
    public class GetPriceProductsByIdGraphQLHandler : IRequestHandler<GetPriceProductsByIdGraphQLQuery, List<PriceProductsResponse>?>
    {
        private readonly IPricesRepository _repository;
        private readonly IMapper _mapper;
        public GetPriceProductsByIdGraphQLHandler(IPricesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<PriceProductsResponse>?> Handle(GetPriceProductsByIdGraphQLQuery query, CancellationToken cancellationToken)
        {
            var priceProducts = await _repository.GetPriceProductsByProductIdAsync(query.ProductId, cancellationToken);

            if (priceProducts == null || !priceProducts.Any())
            {
                return new List<PriceProductsResponse>
                {
                    new PriceProductsResponse
                    {
                        Message = $"Relação entre Preço e Produto com código {query.ProductId} não encontrado.",
                        Success = false
                    }
                };
            }
            return new List<PriceProductsResponse> { _mapper.Map<PriceProductsResponse>(priceProducts) };
        }    
    }
}
