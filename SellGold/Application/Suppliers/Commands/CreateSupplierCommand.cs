using MediatR;
using SellGold.Contracts.DTOs.Suppliers.Requests;

namespace SellGold.Application.Suppliers.Commands
{
    public record CreateSupplierCommand(CreateSupplierRequest CreateSupplierRequest) : IRequest<bool>;
}
