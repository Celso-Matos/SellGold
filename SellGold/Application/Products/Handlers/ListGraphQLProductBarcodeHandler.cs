using MediatR;
using SellGold.Application.Products.Queries;
using SellGold.Contracts.DTOs.Products.Responses;
using SellGold.GraphQL.Products.Services;

namespace SellGold.Application.Products.Handlers
{
    public class ListGraphQLProductBarcodeHandler : IRequestHandler<ListGraphQLProductBarcodeQuery, ProductResponse?>
    {
        private readonly ListProductBarcodeGraphQLService _service;
        public ListGraphQLProductBarcodeHandler(ListProductBarcodeGraphQLService service)
        {
            _service = service;
        }
        public async Task<ProductResponse?> Handle(ListGraphQLProductBarcodeQuery query, CancellationToken cancellationToken)
        {
            var product = await _service.GetProductByBarcodeGraphQLAsync(query.Barcode, cancellationToken);
            return product;
        }
    }
}
