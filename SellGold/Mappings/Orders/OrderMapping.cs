using SellGold.Contracts.DTOs.Orders.Requests;
using SellGold.PageModels.Orders;

namespace SellGold.Mappings.Orders
{
    public static class OrderMapping
    {
        public static CreateOrderRequest ToRequest(OrderPageModel model) =>
            new CreateOrderRequest
            {
                CustomerId = model.CustomerId,
                Items = model.Items?.ToList() ?? new List<CreateOrderItemRequest>(),
                OrderDate = model.OrderDate
            };        
    }
}
