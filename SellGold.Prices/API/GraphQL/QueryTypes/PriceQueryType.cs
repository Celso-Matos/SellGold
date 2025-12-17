using MediatR;
using SellGold.Prices.Application.Contracts.DTOs.Responses;
using SellGold.Prices.Application.Queries.GraphQL;

namespace SellGold.Prices.API.GraphQL.QueryTypes
{
    public class PriceQueryType
    {
        protected PriceQueryType() { 
        
        }

        // Query para buscar preço por ID
        public static async Task<PriceResponse> GetPriceGraphQLByIdAsync(Guid PriceId,
                                                                        [Service] IMediator mediator)
        {
            return await mediator.Send(new GetPriceByIdGraphQLQuery(PriceId));
        }

        // Query para buscar todos os preços
        public static async Task<List<PriceResponse>> GetAllPricesGraphQLAsync(
            [Service] IMediator mediator)
        {
            return await mediator.Send(new GetAllPricesGraphQLQuery());
        }
    }
}
