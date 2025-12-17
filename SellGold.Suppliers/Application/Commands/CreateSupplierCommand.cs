using MediatR;
using SellGold.Suppliers.Application.Contracts.DTOs.Requests;


namespace SellGold.Suppliers.Application.Commands
{
    public record CreateSupplierCommand(SupplierRequest Request) : IRequest<SupplierRequest>;

}
