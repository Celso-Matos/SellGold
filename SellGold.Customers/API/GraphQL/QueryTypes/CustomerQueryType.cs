using MediatR;
using SellGold.Customers.Application.Contracts.DTOs.Responses;
using SellGold.Customers.Application.Queries.GraphQL;

namespace SellGold.Customers.API.GraphQL.QueryTypes
{
    public class CustomerQueryType
    {
        // Query para buscar cliente por ID
        public async Task<CustomerResponse> GetCustomerGraphQLByIdAsync(Guid CustomerId,
                                                                        [Service] IMediator mediator,
                                                                        CancellationToken cancellationToken = default)
        {
            return await mediator.Send(new GetCustomerByIdGraphQLQuery(CustomerId));
        }
        // Query para buscar todos os clientes
        public async Task<List<CustomerResponse>> GetAllCustomersGraphQLAsync(string? cpf,
                                                                                [Service] IMediator mediator,
                                                                                CancellationToken cancellationToken = default)
        {
            return await mediator.Send(new GetAllCustomersGraphQLQuery(cpf, cancellationToken));
        }

        // Query para buscar cliente por CPF
        public async Task<CustomerResponse> GetCustomerGraphQLByCpfAsync(string cpf,
                                                                        [Service] IMediator mediator,
                                                                        CancellationToken cancellationToken = default)
        {
            return await mediator.Send(new GetCustomerByCpfGraphQLQuery(cpf, cancellationToken));
        }
    }
}
