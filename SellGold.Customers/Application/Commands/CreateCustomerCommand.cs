using MediatR;
using SellGold.Customers.Application.Contracts.DTOs.Requests;
using SellGold.Customers.Application.Contracts.DTOs.Responses;

namespace SellGold.Customers.Application.Commands
{
    public record CreateCustomerCommand(CustomerRequest CreateCustomerRequest) : IRequest<CustomerResponse>;
}
