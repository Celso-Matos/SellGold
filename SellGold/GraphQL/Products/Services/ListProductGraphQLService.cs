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
    public class ListProductGraphQLService
    {
        private readonly GraphQLHttpClient _client;

        public ListProductGraphQLService(IOptions<ProductsApiSettings> apiSettings)
        {
            
            var settings = apiSettings.Value; 
            var graphQlEndpoint = $"{settings.BaseUrl}{settings.Endpoints.ProductGraphQL}";
            _client = new GraphQLHttpClient(graphQlEndpoint, new SystemTextJsonSerializer());

        }

        public async Task<List<ProductResponse>> GetAllProductsGraphQLAsync()
        {
            
            var request = new GraphQLRequest
            {
                Query = ListProductGraphQLQuery.GetProducts
            };
            var response = await _client.SendQueryAsync<ProductListWrapper>(request);
            return response.Data.AllProductsGraphQL;

        } 
    }
}
