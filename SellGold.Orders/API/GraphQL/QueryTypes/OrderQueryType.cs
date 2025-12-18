using MediatR;
using SellGold.Orders.Application.Contracts.DTOs.Responses;
using SellGold.Orders.Application.Queries.GraphQL;

namespace SellGold.Orders.API.GraphQL.QueryTypes
{
    public class OrderQueryType
    {
        protected OrderQueryType()
        {

        }

        // Query para buscar pedido por ID
        public static async Task<OrderResponse> GetProductGraphQLByIdAsync(Guid OrderId,
                                                                        [Service] IMediator mediator)
        {
            return await mediator.Send(new GetOrderByIdGraphQLQuery(OrderId));
        }

        // Query para buscar todos os pedidos
        public static async Task<List<OrderResponse>> GetAllOrdersGraphQLAsync(
            [Service] IMediator mediator)
        {
            return await mediator.Send(new GetAllOrdersGraphQLQuery());
        }
    }
}
