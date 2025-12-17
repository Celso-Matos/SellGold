using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Responses;
using SellGold.Products.Application.Contracts.Mappers;
using SellGold.Products.Application.Interfaces.Repositories;
using SellGold.Products.Application.Queries.GraphQL;

namespace SellGold.Products.Application.Handlers.GraphQL
{
    public class GetProductByIdGraphQLHandler : IRequestHandler<GetProductByIdGraphQLQuery, ProductResponse>
    {
        private readonly IProductsRepository _repository;

        public GetProductByIdGraphQLHandler(IProductsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductResponse> Handle(GetProductByIdGraphQLQuery query, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(query.ProductId);
            return product == null ? null! : ProductMapper.ToResponse(product);
        }
    }
}
