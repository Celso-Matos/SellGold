using MediatR;
using Microsoft.AspNetCore.Mvc;
using SellGold.Suppliers.Application.Commands;
using SellGold.Suppliers.Application.Contracts.DTOs.Requests;
using SellGold.Suppliers.Application.Contracts.DTOs.Responses;

namespace SellGold.Suppliers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SuppliersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<SupplierResponse>> CreateSupplier([FromBody] CreateSupplierCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var supplierDto = await _mediator.Send(command);
            return StatusCode(201, supplierDto);
        }
    }

}
