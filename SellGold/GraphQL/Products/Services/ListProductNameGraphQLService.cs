using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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
        public async Task<List<ProductResponse>?> GetProductsGraphQLByNameAsync(string? name, CancellationToken cancellationToken)
        {
            var request = new GraphQLRequest
            {
                Query = ListProductNameGraphQLQuery.GetProductsByName,
                Variables = new { Name = name }
            };
            Console.WriteLine($"Query: {request.Query}");
            Console.WriteLine($"Variables: {JsonConvert.SerializeObject(request.Variables)}");
            var response = await _client.SendQueryAsync<ProductByNameWrapper>(request, cancellationToken);           
            return response.Data.ProductsGraphQLByName;
        }
    }
}
