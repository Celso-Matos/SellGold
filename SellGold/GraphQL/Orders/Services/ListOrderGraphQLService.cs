using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.Extensions.Options;
using SellGold.Configurations.Orders;
using SellGold.Contracts.DTOs.Orders.Responses;
using SellGold.GraphQL.Orders.Queries;
using SellGold.GraphQL.Orders.Responses;

namespace SellGold.GraphQL.Orders.Services
{
    public class ListOrderGraphQLService
    {
        private readonly GraphQLHttpClient _client;

        public ListOrderGraphQLService(IOptions<OrdersApiSettings> apiSettings)
        {
            var settings = apiSettings.Value;
            var graphQlEndpoint = $"{settings.BaseUrl}{settings.Endpoints.GetOrdersGraphQL}";
            _client = new GraphQLHttpClient(graphQlEndpoint, new SystemTextJsonSerializer());
        }

        public async Task<List<OrderResponse>> GetAllOrdersGraphQLAsync(CancellationToken cancellationToken)
        {
            var request = new GraphQLRequest
            {
                Query = ListOrdersGraphQLQuery.GetOrders
            };
            var response = await _client.SendQueryAsync<OrderListWrapper>(request, cancellationToken);
            return response.Data.AllOrdersGraphQL;
        }
    }
}
