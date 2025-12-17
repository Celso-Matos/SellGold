using MediatR;
using Microsoft.AspNetCore.Mvc;
using SellGold.Customers.Application.Commands;
using SellGold.Customers.Application.Queries.Customers;
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

        [HttpGet("{customerId:guid}")]
        public async Task<IActionResult> GetCustomerDetails(Guid customerId, CancellationToken cancellationToken)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery(customerId), cancellationToken);
            if (customer == null)
                return NotFound($"Customer with id {customerId} not found.");
            return Ok(customer);
        }
    }
}
