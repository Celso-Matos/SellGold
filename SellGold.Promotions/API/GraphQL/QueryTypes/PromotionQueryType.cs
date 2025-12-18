using MediatR;
using SellGold.Promotions.Application.Contracts.DTOs.Responses;
using SellGold.Promotions.Application.Queries.GraphQL;

namespace SellGold.Promotions.API.GraphQL.QueryTypes
{
    public class PromotionQueryType
    {
        protected PromotionQueryType()
        {

        }

        // Query para buscar promoção por ID
        public static async Task<PromotionResponse> GetPromotionGraphQLByIdAsync(Guid PromotionId,
                                                                                    [Service] IMediator mediator)
        {

            return await mediator.Send(new GetPromotionByIdGraphQLQuery(PromotionId));
        }

        // Query para buscar todas as promoções
        public static async Task<List<PromotionResponse>> GetAllPromotionsGraphQLAsync([Service] IMediator mediator)
        {
            return await mediator.Send(new GetAllPromotionGraphQLQuery());
        }
    }
}
