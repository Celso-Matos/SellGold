using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Responses;
using SellGold.Products.Application.Queries.GraphQL;

namespace SellGold.Products.API.GraphQL.QueryTypes
{
    public class ProductQueryType
    {
        
        // Query para buscar produto por ID
        public async Task<ProductResponse> GetProductGraphQLByIdAsync(Guid ProductId,
                                                                        [Service] IMediator mediator)
        {
            return await mediator.Send(new GetProductByIdGraphQLQuery(ProductId));
        }

        // Query para buscar todos os produtos
        public async Task<List<ProductResponse>> GetAllProductsGraphQLAsync(
            [Service] IMediator mediator)
        {
            return await mediator.Send(new GetAllProductsGraphQLQuery());
        }

        // Query para buscar produtos por nome
        public async Task<List<ProductResponse>?> GetProductsGraphQLByNameAsync(
            string? Name,
            [Service] IMediator mediator)
        {
            return await mediator.Send(new GetProductByNameGraphQLQuery(Name));
        }

        // Query para buscar produto por código de barras
        public async Task<ProductResponse?> GetProductGraphQLByBarcodeAsync(
            string BarCode,
            [Service] IMediator mediator)
        {
            return await mediator.Send(new GetProductByBarcodeGraphQLQuery(BarCode));
        }

    }
}
