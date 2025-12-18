using MediatR;
using Microsoft.AspNetCore.Mvc;
using SellGold.Customers.Application.Commands;
using SellGold.Customers.Application.Contracts.DTOs.Responses;

namespace SellGold.Customers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<ActionResult<CustomerResponse>> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customerDto = await _mediator.Send(command);
            return StatusCode(201, customerDto);
        }        
    }
}
