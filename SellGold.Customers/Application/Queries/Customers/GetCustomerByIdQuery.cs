using MediatR;
using SellGold.Customers.Application.Contracts.DTOs.Responses;

namespace SellGold.Customers.Application.Queries.Customers
{
    public record GetCustomerByIdQuery(Guid CustomerId) : IRequest<CustomerResponse>;
}
