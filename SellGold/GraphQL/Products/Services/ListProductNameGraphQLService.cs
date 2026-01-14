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
    public class ListProductNameGraphQLService
    {
        private readonly GraphQLHttpClient _client;
        public ListProductNameGraphQLService(IOptions<ProductsApiSettings> apiSettings)
        {
            var settings = apiSettings.Value;
            var graphQlEndpoint = $"{settings.BaseUrl}{settings.Endpoints.GetProductsGraphQL}";
            _client = new GraphQLHttpClient(graphQlEndpoint, new SystemTextJsonSerializer());
        }
        public async Task<List<ProductResponse>?> GetProductsByNameGraphQLAsync(string? name, CancellationToken cancellationToken)
        {
            var request = new GraphQLRequest
            {
                Query = ListProductNameGraphQLQuery.GetProductsByName,
                Variables = new { Name = name }
            };
            var response = await _client.SendQueryAsync<ProductByNameWrapper>(request, cancellationToken);
            return response.Data.ProductsGraphQLByName;
        }
    }
}
