using MediatR;
using AutoMapper;
using SellGold.Products.Application.Contracts.DTOs.Responses;
using SellGold.Products.Application.Interfaces.Repositories;
using SellGold.Products.Application.Queries.GraphQL;

namespace SellGold.Products.Application.Handlers.GraphQL
{
    public class GetProductByIdGraphQLHandler : IRequestHandler<GetProductByIdGraphQLQuery, ProductResponse>
    {
        private readonly IProductsRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdGraphQLHandler(IProductsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductResponse> Handle(GetProductByIdGraphQLQuery query, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(query.ProductId);
            return product == null ? null! : _mapper.Map<ProductResponse>(product);
        }
    }
}
