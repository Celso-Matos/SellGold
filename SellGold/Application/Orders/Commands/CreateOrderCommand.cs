using MediatR;
using SellGold.Contracts.DTOs.Orders.Requests;

namespace SellGold.Application.Orders.Commands
{
    public record CreateOrderCommand(CreateOrderRequest createOrderRequest) : IRequest<bool>;
}
