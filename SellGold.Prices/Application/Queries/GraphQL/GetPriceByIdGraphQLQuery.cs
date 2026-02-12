using MediatR;
using SellGold.Prices.Application.Contracts.DTOs.Responses;

namespace SellGold.Prices.Application.Queries.GraphQL
{
    public class GetPriceByIdGraphQLQuery : IRequest<PriceResponse?>
    {
        public Guid PriceId { get; }

        public GetPriceByIdGraphQLQuery(Guid priceId, CancellationToken cancellationToken = default)
        {
            PriceId = priceId;
        }
    }

}