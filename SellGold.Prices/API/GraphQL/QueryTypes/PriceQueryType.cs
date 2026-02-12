using MediatR;
using SellGold.Prices.Application.Contracts.DTOs.Responses;
using SellGold.Prices.Application.Queries.GraphQL;

namespace SellGold.Prices.API.GraphQL.QueryTypes
{
    public class PriceQueryType
    {
        // Query para buscar preço por ID
        public async Task<PriceResponse> GetAllPricesByIdGraphQLAsync(Guid PriceId,
                                                                        [Service] IMediator mediator)
            => await mediator.Send(new GetPriceByIdGraphQLQuery(PriceId));

        // Query para buscar todos os preços
        public async Task<List<PriceResponse>> GetAllPricesGraphQLAsync(
                                                                        [Service] IMediator mediator) 
            => await mediator.Send(new GetAllPricesGraphQLQuery());

        // Query para buscar os preços de um produto específico allPriceProductsGraphQL
        public async Task<List<PriceProductsResponse>?> GetAllPricesProductsByIdGraphQLAsync(Guid ProductId,
                                                                        [Service] IMediator mediator) 
            => await mediator.Send(new GetPriceProductsByIdGraphQLQuery(ProductId));
    }
}
