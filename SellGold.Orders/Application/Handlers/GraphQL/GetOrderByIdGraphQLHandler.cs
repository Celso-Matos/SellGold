using AutoMapper;
using MediatR;
using SellGold.Orders.Application.Commons;
using SellGold.Orders.Application.Contracts.DTOs.Responses;
using SellGold.Orders.Application.Interfaces.Repositories;
using SellGold.Orders.Application.Queries.GraphQL;

namespace SellGold.Orders.Application.Handlers.GraphQL
{
    public class GetOrderByIdGraphQLHandler : IRequestHandler<GetOrderByIdGraphQLQuery, OrderResponse>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetOrderByIdGraphQLHandler(IOrdersRepository ordersRepository, IMapper mapper, ILogger<GetOrderByIdGraphQLHandler> logger)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OrderResponse> Handle(GetOrderByIdGraphQLQuery query, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetByIdAsync(query.OrderId);
            if (order == null)
            {
                OrderLogs.OrderNotFound(_logger, query.OrderId);
                throw new NotFoundException("Orders", query.OrderId);
            }
            var response = _mapper.Map<OrderResponse>(order);

            return response;
        }
    }
}
