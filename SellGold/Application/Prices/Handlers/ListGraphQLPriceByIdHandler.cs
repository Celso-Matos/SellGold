using MediatR;
using SellGold.Application.Prices.Queries;
using SellGold.Contracts.DTOs.Prices.Responses;
using SellGold.GraphQL.Prices.Services;

namespace SellGold.Application.Prices.Handlers
{
    public class ListGraphQLPriceByIdHandler : IRequestHandler<ListGraphQLPriceByIdQuery, List<PriceResponse>?>
    {
        private readonly ListPriceByIdGraphQLService _service;
        public ListGraphQLPriceByIdHandler(ListPriceByIdGraphQLService service)
        {
            _service = service;
        }
        public async Task<List<PriceResponse>?> Handle(ListGraphQLPriceByIdQuery query, CancellationToken cancellationToken)
        {
            var prices = await _service.GetAllPricesByIdGraphQLAsync(query.PriceId, cancellationToken);
            return prices;
        }    
    }
}
