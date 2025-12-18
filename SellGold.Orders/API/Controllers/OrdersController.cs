using MediatR;
using Microsoft.AspNetCore.Mvc;
using SellGold.Orders.Application.Commands;
using SellGold.Orders.Application.Contracts.DTOs.Responses;

namespace SellGold.Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        { 
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponse>> CreateOrder([FromBody] CreateOrderCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orderDto = await _mediator.Send(command);
            return StatusCode(201, orderDto);
        }
    }
}
