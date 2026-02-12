using MediatR;
using SellGold.Prices.Application.Contracts.DTOs.Responses;

namespace SellGold.Prices.Application.Queries.GraphQL
{
    public class GetPriceProductsByIdGraphQLQuery: IRequest<List<PriceProductsResponse>?>
    {
        public Guid ProductId { get; }

        public GetPriceProductsByIdGraphQLQuery(Guid productId, CancellationToken cancellationToken = default)
        {
            ProductId = productId;
        }
    }
}
