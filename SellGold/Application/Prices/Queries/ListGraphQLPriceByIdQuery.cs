using MediatR;
using SellGold.Contracts.DTOs.Prices.Responses;

namespace SellGold.Application.Prices.Queries
{
    public class ListGraphQLPriceByIdQuery : IRequest<List<PriceResponse>?>
    {
        public Guid? PriceId { get; }
        public ListGraphQLPriceByIdQuery(Guid? priceId, CancellationToken cancellationToken = default)
        {
            PriceId = priceId;
        }
    }
}
