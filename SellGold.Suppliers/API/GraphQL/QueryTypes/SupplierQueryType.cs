using MediatR;
using SellGold.Suppliers.Application.Contracts.DTOs.Responses;
using SellGold.Suppliers.Application.Queries.GraphQL;

namespace SellGold.Suppliers.API.GraphQL.QueryTypes
{
    public class SupplierQueryType
    {
        protected SupplierQueryType()
        {
        }
        // Query para buscar fornecedor por ID
        public static async Task<SupplierResponse> GetSupplierGraphQLByIdAsync(Guid SupplierId,
                                                                        [Service] IMediator mediator)
        {
            return await mediator.Send(new GetSupplierByIdGraphQLQuery(SupplierId));
        }
        // Query para buscar todos os fornecedores
        public static async Task<List<SupplierResponse>> GetAllSuppliersGraphQLAsync(
            [Service] IMediator mediator)
        {
            return await mediator.Send(new GetAllSuppliersGraphQLQuery());
        }
    }
}
