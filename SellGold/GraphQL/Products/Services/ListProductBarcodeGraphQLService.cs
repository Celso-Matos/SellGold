using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.Extensions.Options;
using SellGold.Configurations.Products;
using SellGold.Contracts.DTOs.Products.Responses;
using SellGold.GraphQL.Products.Queries;
using SellGold.GraphQL.Products.Responses;

namespace SellGold.GraphQL.Products.Services
{
    public class ListProductBarcodeGraphQLService
    {
        private readonly GraphQLHttpClient _client;

        public ListProductBarcodeGraphQLService(IOptions<ProductsApiSettings> apiSettings)
        {
            var settings = apiSettings.Value;
            var graphQlEndpoint = $"{settings.BaseUrl}{settings.Endpoints.GetProductsGraphQL}";
            _client = new GraphQLHttpClient(graphQlEndpoint, new SystemTextJsonSerializer());
        }

        public async Task<ProductResponse?> GetProductByBarcodeGraphQLAsync(string? barcode, CancellationToken cancellationToken)
        {
            var request = new GraphQLRequest
            {
                Query = ListProductBarcodeGraphQLQuery.GetProductByBarcode,
                Variables = new { Barcode = barcode }
            };
            var response = await _client.SendQueryAsync<ProductByBarcodeWrapper>(request, cancellationToken);
            return response.Data.ProductByBarcodeGraphQL;
        }
    }
}
