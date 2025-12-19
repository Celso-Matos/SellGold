using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.Extensions.Options;
using SellGold.Configurations.Promotions;
using SellGold.Contracts.DTOs.Promotions.Responses;
using SellGold.GraphQL.Promotions.Queries;
using SellGold.GraphQL.Promotions.Responses;

namespace SellGold.GraphQL.Promotions.Services
{
    public class ListPromotionGraphQLService
    {
        private readonly GraphQLHttpClient _client;

        public ListPromotionGraphQLService(IOptions<PromotionsApiSettings> apiSettings)
        {
            var settings = apiSettings.Value;
            var graphQlEndpoint = $"{settings.BaseUrl}{settings.Endpoints.GetPromotionsGraphQL}";
            _client = new GraphQLHttpClient(graphQlEndpoint, new SystemTextJsonSerializer());
        }

        public async Task<List<PromotionResponse>> GetAllPromotionsGraphQLAsync(CancellationToken cancellationToken)
        {
            var request = new GraphQLRequest
            {
                Query = ListPromotionGraphQLQuery.GetPromotions
            };
            var response = await _client.SendQueryAsync<PromotionListWrapper>(request, cancellationToken);
            return response.Data.AllPromotionsGraphQL;
        }
    }
}
