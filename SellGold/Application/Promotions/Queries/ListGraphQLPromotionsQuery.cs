using MediatR;
using SellGold.Contracts.DTOs.Promotions.Responses;

namespace SellGold.Application.Promotions.Queries
{
    public record ListGraphQLPromotionsQuery() : IRequest<List<PromotionResponse>>;
}
