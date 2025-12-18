using MediatR;
using SellGold.Promotions.Application.Contracts.DTOs.Responses;

namespace SellGold.Promotions.Application.Queries.GraphQL
{
    public class GetAllPromotionGraphQLQuery() : IRequest<List<PromotionResponse>>;
}
