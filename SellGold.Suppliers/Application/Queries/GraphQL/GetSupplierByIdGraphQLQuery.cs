using MediatR;
using SellGold.Suppliers.Application.Contracts.DTOs.Responses;

namespace SellGold.Suppliers.Application.Queries.GraphQL
{
    public record GetSupplierByIdGraphQLQuery(Guid SupplierId) : IRequest<SupplierResponse>;
}
