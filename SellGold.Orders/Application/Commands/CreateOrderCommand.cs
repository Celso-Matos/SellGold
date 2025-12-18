using MediatR;
using SellGold.Orders.Application.Contracts.DTOs.Requests;
using SellGold.Orders.Application.Contracts.DTOs.Responses;

namespace SellGold.Orders.Application.Commands
{
    public record CreateOrderCommand(CreateOrderRequest createOrderRequest) : IRequest<OrderResponse>;
}
