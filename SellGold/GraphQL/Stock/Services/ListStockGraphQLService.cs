using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.Extensions.Options;
using SellGold.Configurations.Stock;
using SellGold.Contracts.DTOs.Stock.Responses;
using SellGold.GraphQL.Stock.Queries;
using SellGold.GraphQL.Stock.Responses;

namespace SellGold.GraphQL.Stock.Services
{
    public class ListStockGraphQLService
    {
        private readonly GraphQLHttpClient _client;
        public ListStockGraphQLService(IOptions<StockApiSettings> apiSettings)
        {
            
            var settings = apiSettings.Value;
            var graphQlEndpoint = $"{settings.BaseUrl}{settings.Endpoints.GetStockGraphQL}";
            _client = new GraphQLHttpClient(graphQlEndpoint, new SystemTextJsonSerializer());

        }
        public async Task<List<StockResponse>> GetAllStockGraphQLAsync()
        {
            
            var request = new GraphQLRequest
            {
                Query = ListStockGraphQLQuery.GetStock
            };
            var response = await _client.SendQueryAsync<StockListWrapper>(request);
            return response.Data.AllStockGraphQL;

        }
    }
}
