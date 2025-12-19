using MediatR;
using SellGold.Contracts.DTOs.Customers.Requests;

namespace SellGold.Application.Customers.Commands
{
    public record CreateCustomerCommand(CreateCustomerRequest createCustomerRequest) : IRequest<bool>;
}
