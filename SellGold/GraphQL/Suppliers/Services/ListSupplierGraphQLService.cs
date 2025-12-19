using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.Extensions.Options;
using SellGold.Configurations.Suppliers;
using SellGold.Contracts.DTOs.Suppliers.Responses;
using SellGold.GraphQL.Suppliers.Queries;
using SellGold.GraphQL.Suppliers.Responses;

namespace SellGold.GraphQL.Suppliers.Services
{
    public class ListSupplierGraphQLService
    {
        private readonly GraphQLHttpClient _client;
        public ListSupplierGraphQLService(IOptions<SuppliersApiSettings> apiSettings)
        {
            
            var settings = apiSettings.Value;
            var graphQlEndpoint = $"{settings.BaseUrl}{settings.Endpoints.GetSuppliersGraphQL}";
            _client = new GraphQLHttpClient(graphQlEndpoint, new SystemTextJsonSerializer());

        }
        public async Task<List<SupplierResponse>> GetAllSuppliersGraphQLAsync()
        {
            
            var request = new GraphQLRequest
            {
                Query = ListSupplierGraphQLQuery.GetSuppliers
            };
            var response = await _client.SendQueryAsync<SupplierListWrapper>(request);
            return response.Data.AllSuppliersGraphQL;

        }
    }
}
