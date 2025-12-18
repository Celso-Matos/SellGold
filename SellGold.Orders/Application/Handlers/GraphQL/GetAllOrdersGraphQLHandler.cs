using AutoMapper;
using MediatR;
using SellGold.Orders.Application.Contracts.DTOs.Responses;
using SellGold.Orders.Application.Interfaces.Repositories;
using SellGold.Orders.Application.Queries.GraphQL;

namespace SellGold.Orders.Application.Handlers.GraphQL
{
    public class GetAllOrdersGraphQLHandler : IRequestHandler<GetAllOrdersGraphQLQuery, List<OrderResponse>>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public GetAllOrdersGraphQLHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderResponse>> Handle(GetAllOrdersGraphQLQuery query, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.GetAllAsync();
            return _mapper.Map<List<OrderResponse>>(order);
            
        }
    }
}
