using MediatR;
using SellGold.Application.Products.Queries;
using SellGold.Contracts.DTOs.Products.Responses;
using SellGold.GraphQL.Products.Services;

namespace SellGold.Application.Products.Handlers
{
    public class ListGraphQLProductsHandler : IRequestHandler<ListGraphQLProductsQuery, List<ProductResponse>>
    {
        private readonly ListProductGraphQLService _service;
        public ListGraphQLProductsHandler(ListProductGraphQLService service)
        {
            _service = service;
        }
        public async Task<List<ProductResponse>> Handle(ListGraphQLProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _service.GetAllProductsGraphQLAsync(cancellationToken);
            return products ?? new List<ProductResponse>();
        }
    }
}
