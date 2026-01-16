using MediatR;
using SellGold.Application.Products.Queries;
using SellGold.Contracts.DTOs.Products.Responses;
using SellGold.GraphQL.Products.Services;

namespace SellGold.Application.Products.Handlers
{
    public class ListGraphQLProductNameHandler : IRequestHandler<ListGraphQLProductNameQuery, List<ProductResponse>?>
    {
        private readonly ListProductNameGraphQLService _service;
        public ListGraphQLProductNameHandler(ListProductNameGraphQLService service)
        {
            _service = service;
        }
        public async Task<List<ProductResponse>?> Handle(ListGraphQLProductNameQuery query, CancellationToken cancellationToken)
        {
            var products = await _service.GetProductsGraphQLByNameAsync(query.Name, cancellationToken);
            return products;
        }
    }
}
