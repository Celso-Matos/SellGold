using MediatR;
using SellGold.Contracts.DTOs.Suppliers.Responses;

namespace SellGold.Application.Suppliers.Queries
{
    public record ListGraphQLSuppliersQuery() : IRequest<List<SupplierResponse>>;
}
