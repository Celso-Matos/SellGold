using MediatR;
using SellGold.Customers.Application.Contracts.DTOs.Responses;
using SellGold.Customers.Application.Queries.GraphQL;

namespace SellGold.Customers.API.GraphQL.QueryTypes
{
    public class CustomerQueryType
    {
        protected CustomerQueryType() {
        }
        // Query para buscar cliente por ID
        public static async Task<CustomerResponse> GetCustomerGraphQLByIdAsync(Guid CustomerId,
                                                                        [Service] IMediator mediator)
        {
            return await mediator.Send(new GetCustomerByIdGraphQLQuery(CustomerId));
        }
        // Query para buscar todos os clientes
        public static async Task<List<CustomerResponse>> GetAllCustomersGraphQLAsync(
            [Service] IMediator mediator)
        {
            return await mediator.Send(new GetAllCustomersGraphQLQuery());
        }
    }
}
