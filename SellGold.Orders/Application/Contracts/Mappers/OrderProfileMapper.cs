using AutoMapper;
using SellGold.Orders.Application.Contracts.DTOs.Requests;
using SellGold.Orders.Application.Contracts.DTOs.Responses;
using SellGold.Orders.Domain.Entities;

namespace SellGold.Orders.Application.Contracts.Mappers
{
    public class OrderProfileMapper : Profile
    {
        public OrderProfileMapper()
        {
            CreateMap<CreateOrderRequest, Order>()
                .ConstructUsing(src =>
                    new Order(
                        src.CustomerId,
                        src.Items.Select(i =>
                            new OrderItem(i.ProductId, i.Quantity, i.UnitPrice)),
                        src.OrderDate ?? DateTime.UtcNow
                    )
                );

            CreateMap<Order, OrderResponse>()
                .ForMember(dest => dest.Status, opt =>
                    opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.TotalValue, opt =>
                    opt.MapFrom(src => src.TotalValue));

            CreateMap<OrderItem, OrderItemResponse>();

        }
    }
}
