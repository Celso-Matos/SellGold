using MediatR;
using Microsoft.AspNetCore.Mvc;
using SellGold.Prices.Application.Commands;
using SellGold.Prices.Application.Queries.Prices;
using SellGold.Prices.Application.Contracts.DTOs.Responses;

namespace SellGold.Prices.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PricesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{priceId:guid}")]
        public async Task<IActionResult> GetPriceById(Guid priceId, CancellationToken cancellationToken)
        {
            var price = await _mediator.Send(new GetPriceByIdQuery(priceId), cancellationToken);
            if (price == null)
                return NotFound($"Price with id {priceId} not found.");
            return Ok(price);
        }
        [HttpPost]
        public async Task<ActionResult<PriceResponse>> CreatePrice([FromBody] CreatePriceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var priceDto = await _mediator.Send(command);
            return StatusCode(201, priceDto);
        }
    }
}
