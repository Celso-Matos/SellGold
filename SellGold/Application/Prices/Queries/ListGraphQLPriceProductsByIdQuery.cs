using MediatR;
using SellGold.Contracts.DTOs.Prices.Responses;

namespace SellGold.Application.Prices.Queries
{
    public class ListGraphQLPriceProductsByIdQuery : IRequest<List<PriceProductsResponse>?>
    {
        public Guid? ProductId { get; }
        public ListGraphQLPriceProductsByIdQuery(Guid? productId, CancellationToken cancellationToken = default)
        {
            ProductId = productId;
        }
    }
}
