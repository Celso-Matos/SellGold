using AutoMapper;
using MediatR;
using SellGold.Orders.Application.Commands;
using SellGold.Orders.Application.Contracts.DTOs.Responses;
using SellGold.Orders.Application.Interfaces.Repositories;
using SellGold.Orders.Domain.Entities;

namespace SellGold.Orders.Application.Handlers.Orders
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderResponse>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public CreateOrderHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<OrderResponse> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(command.createOrderRequest);

            await _ordersRepository.AddAsync(order);

            var response = _mapper.Map<OrderResponse>(order);

            return response;
        
        }
    }
}
