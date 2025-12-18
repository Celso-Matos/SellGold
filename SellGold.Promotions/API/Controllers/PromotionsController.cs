using MediatR;
using Microsoft.AspNetCore.Mvc;
using SellGold.Promotions.Application.Commands;
using SellGold.Promotions.Application.Contracts.DTOs.Responses;

namespace SellGold.Promotions.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PromotionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<PromotionResponse>> CreatePromotion([FromBody] CreatePromotionCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var promotionDto = await _mediator.Send(command);
            return StatusCode(201, promotionDto);
        }

        /// <summary>
        /// Ativa uma promoção previamente criada
        /// </summary>
        [HttpPost("{promotionId:guid}/activate")]
        public async Task<ActionResult> ActivatePromotion([FromRoute] Guid promotionId,
        CancellationToken cancellationToken)
        {
            var command = new ActivatePromotionCommand(promotionId);

            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
