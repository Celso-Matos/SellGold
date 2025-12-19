using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.Extensions.Options;
using SellGold.Configurations.Customers;
using SellGold.Contracts.DTOs.Customers.Responses;
using SellGold.GraphQL.Customers.Queries;
using SellGold.GraphQL.Customers.Responses;

namespace SellGold.GraphQL.Customers.Services
{
    public class ListCustomerGraphQLService
    {
        private readonly GraphQLHttpClient _client;

        public ListCustomerGraphQLService(IOptions<CustomersApiSettings> apiSettings)
        {

            var settings = apiSettings.Value;
            var graphQlEndpoint = $"{settings.BaseUrl}{settings.Endpoints.GetCustomersGraphQL}";
            _client = new GraphQLHttpClient(graphQlEndpoint, new SystemTextJsonSerializer());

        }

        public async Task<List<CustomerResponse>> GetAllCustomersGraphQLAsync(CancellationToken cancellationToken)
        {

            var request = new GraphQLRequest
            {
                Query = ListCustomerGraphQLQuery.GetCustomers
            };
            var response = await _client.SendQueryAsync<CustomerListWrapper>(request, cancellationToken);
            return response.Data.AllCustomersGraphQL;

        }
    }
}
