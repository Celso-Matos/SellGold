using MediatR;
using SellGold.Suppliers.Application.Contracts.DTOs.Responses;

namespace SellGold.Suppliers.Application.Queries.GraphQL
{
    public class GetAllSuppliersGraphQLQuery() : IRequest<List<SupplierResponse>>;
}
