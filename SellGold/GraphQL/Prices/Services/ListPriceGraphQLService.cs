using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.Extensions.Options;
using SellGold.Configurations.Prices;
using SellGold.Contracts.DTOs.Prices.Responses;
using SellGold.GraphQL.Prices.Queries;
using SellGold.GraphQL.Prices.Responses;

namespace SellGold.GraphQL.Prices.Services
{
    public class ListPriceGraphQLService
    {
        private readonly GraphQLHttpClient _client;
        public ListPriceGraphQLService(IOptions<PricesApiSettings> apiSettings)
        {
            var settings = apiSettings.Value; 
            var graphQlEndpoint = $"{settings.BaseUrl}{settings.Endpoints.PriceGraphQL}";
            _client = new GraphQLHttpClient(graphQlEndpoint, new SystemTextJsonSerializer());
        }
        public async Task<List<PriceResponse>> GetAllPricesGraphQLAsync()
        {
            var request = new GraphQLRequest
            {
                Query = ListPriceGraphQLQuery.GetPrices
            };
            var response = await _client.SendQueryAsync<PriceListWrapper>(request);
            return response.Data.AllPricesGraphQL;
        }   
    }
}
