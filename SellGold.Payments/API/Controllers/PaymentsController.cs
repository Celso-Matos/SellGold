using MediatR;
using Microsoft.AspNetCore.Mvc;
using SellGold.Payments.Application.Commands;
using SellGold.Payments.Application.Contracts.DTOs.Responses;

namespace SellGold.Payments.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<PaymentResponse>> CreatePayment([FromBody] CreatePaymentCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var paymentDto = await _mediator.Send(command);
            return StatusCode(201, paymentDto);
        } 
    }
}
