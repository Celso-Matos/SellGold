using MediatR;
using SellGold.Promotions.Application.Contracts.DTOs.Responses;

namespace SellGold.Promotions.Application.Queries.GraphQL
{
    public record GetPromotionByIdGraphQLQuery(Guid PromotionId) : IRequest<PromotionResponse>;
}
