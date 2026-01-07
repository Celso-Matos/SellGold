using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.Extensions.Options;
using SellGold.Configurations.Customers;
using SellGold.Contracts.DTOs.Payments.Responses;
using SellGold.GraphQL.Payments.Queries;
using SellGold.GraphQL.Payments.Responses;

namespace SellGold.GraphQL.Payments.Services
{
    public class ListPaymentCpfGraphQLService
    {
        private readonly GraphQLHttpClient _client;
        public ListPaymentCpfGraphQLService(IOptions<CustomersApiSettings> apiSettings)
        {
            var settings = apiSettings.Value;
            var graphQlEndpoint = $"{settings.BaseUrl}{settings.Endpoints.GetCustomersGraphQL}";
            _client = new GraphQLHttpClient(graphQlEndpoint, new SystemTextJsonSerializer());
        }                                            
        public async Task<CustomerResponse> GetCustomerGraphQLByCpfAsync(string cpf,
                                                                        CancellationToken cancellationToken = default)
        {
            var request = new GraphQLRequest
            {
                Query = ListPaymentCpfGraphQLQuery.GetPaymentCpf,
                Variables = new { cpf }
            };
            var response = await _client.SendQueryAsync<PaymentCpfWrapper>(request, cancellationToken);
            return response.Data.CustomerGraphQLByCpf;
        }
    }
}
