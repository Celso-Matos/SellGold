using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Responses;
using SellGold.Products.Application.Contracts.Mappers;
using SellGold.Products.Application.Interfaces.Repositories;
using SellGold.Products.Application.Queries.GraphQL;

namespace SellGold.Products.Application.Handlers.GraphQL
{
    public class GetAllProductsGraphQLHandler : IRequestHandler<GetAllProductsGraphQLQuery, List<ProductResponse>>
    {
        private readonly IProductsRepository _repository;

        public GetAllProductsGraphQLHandler(IProductsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductResponse>> Handle(GetAllProductsGraphQLQuery query, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();
            return ProductMapper.ToResponseList(products);

        }
    }
}
