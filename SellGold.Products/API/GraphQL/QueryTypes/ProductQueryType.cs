using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Responses;
using SellGold.Products.Application.Queries.GraphQL;

namespace SellGold.Products.API.GraphQL.QueryTypes
{
    public class ProductQueryType
    {
        protected ProductQueryType() {

        }

        // Query para buscar produto por ID
        public static async Task<ProductResponse> GetProductGraphQLByIdAsync(Guid ProductId,
                                                                        [Service] IMediator mediator)
        {
            return await mediator.Send(new GetProductByIdGraphQLQuery(ProductId));
        }

        // Query para buscar todos os produtos
        public static async Task<List<ProductResponse>> GetAllProductsGraphQLAsync(
            [Service] IMediator mediator)
        {
            return await mediator.Send(new GetAllProductsGraphQLQuery());
        }

    }
}
