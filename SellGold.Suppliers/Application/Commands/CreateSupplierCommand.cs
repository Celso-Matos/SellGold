using MediatR;
using SellGold.Suppliers.Application.Contracts.DTOs.Requests;
using SellGold.Suppliers.Application.Contracts.DTOs.Responses;

namespace SellGold.Suppliers.Application.Commands
{
    public record CreateSupplierCommand(CreateSupplierRequest createSupplierRequest) : IRequest<SupplierResponse>;

}
