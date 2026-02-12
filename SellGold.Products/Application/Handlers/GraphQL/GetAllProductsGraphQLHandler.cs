using AutoMapper;
using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Responses;
using SellGold.Products.Application.Interfaces.Repositories;
using SellGold.Products.Application.Queries.GraphQL;

namespace SellGold.Products.Application.Handlers.GraphQL
{
    public class GetAllProductsGraphQLHandler : IRequestHandler<GetAllProductsGraphQLQuery, List<ProductResponse>>
    {
        private readonly IProductsRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductsGraphQLHandler(IProductsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductResponse>> Handle(GetAllProductsGraphQLQuery query, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductResponse>>(products);

        }
    }
}
