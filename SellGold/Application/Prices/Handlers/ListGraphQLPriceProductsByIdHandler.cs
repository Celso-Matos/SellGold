using MediatR;
using SellGold.Application.Prices.Queries;
using SellGold.Contracts.DTOs.Prices.Responses;
using SellGold.GraphQL.Prices.Services;

namespace SellGold.Application.Prices.Handlers
{
    public class ListGraphQLPriceProductsByIdHandler : IRequestHandler<ListGraphQLPriceProductsByIdQuery, List<PriceProductsResponse>?>
    {
        private readonly ListPriceProductsByIdGraphQLService _service;
        public ListGraphQLPriceProductsByIdHandler(ListPriceProductsByIdGraphQLService service)
        {
            _service = service;
        }
        public async Task<List<PriceProductsResponse>?> Handle(ListGraphQLPriceProductsByIdQuery query, CancellationToken cancellationToken)
        {
            var prices = await _service.GetAllPricesProductsByIdGraphQLAsync(query.ProductId, cancellationToken);
            return prices;
        }    
    }
}
