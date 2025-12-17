using MediatR;
using SellGold.Application.Products.Queries;
using SellGold.Contracts.DTOs.Products.Responses;
using SellGold.GraphQL.Products.Services;

namespace SellGold.Application.Products.Handlers
{
    public class ListProductHandler: IRequestHandler<ListProductQuery, List<ProductResponse>>
    {
        private readonly ListProductGraphQLService _service;

        public ListProductHandler(ListProductGraphQLService service)
        {
            _service = service;
        }

        public async Task<List<ProductResponse>> Handle(ListProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _service.GetAllProductsGraphQLAsync();
            return products ?? new List<ProductResponse>();
        }
    }
}
