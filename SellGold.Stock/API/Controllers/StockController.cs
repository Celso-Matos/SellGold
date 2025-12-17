using MediatR;
using Microsoft.AspNetCore.Mvc;
using SellGold.Stock.Application.Commands;
using SellGold.Stock.Application.Contracts.DTOs.Requests;
using SellGold.Stock.Application.Contracts.DTOs.Responses;

namespace SellGold.Stock.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<StockProductResponse>> CreateStockProduct([FromBody] CreateStockCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockProductDto = await _mediator.Send(command);
            return StatusCode(201, stockProductDto);
        }
    }
}
