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
    public class ListPriceByIdGraphQLService
    {
        private readonly GraphQLHttpClient _client;
        public ListPriceByIdGraphQLService(IOptions<PricesApiSettings> apiSettings)
        {
            var settings = apiSettings.Value; 
            var graphQlEndpoint = $"{settings.BaseUrl}{settings.Endpoints.GetPricesGraphQL}";
            _client = new GraphQLHttpClient(graphQlEndpoint, new SystemTextJsonSerializer());
        }
        public async Task<List<PriceResponse>> GetAllPricesByIdGraphQLAsync(Guid? priceId, CancellationToken cancellationToken)
        {
            var request = new GraphQLRequest
            {
                Query = ListPriceByIdGraphQLQuery.GetPricesById,
                Variables = new
                {
                    PriceId = priceId
                }
            };
            var response = await _client.SendQueryAsync<PriceByIdListWrapper>(request);
            return response.Data.AllPricesByIdGraphQL;
        }   
    }
}
