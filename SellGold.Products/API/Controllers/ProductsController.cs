using MediatR;
using Microsoft.AspNetCore.Mvc;
using SellGold.Products.Application.Commands;
using SellGold.Products.Application.Queries.Products;
using SellGold.Products.Application.Contracts.DTOs.Requests;
using SellGold.Products.Application.Contracts.DTOs.Responses;


namespace SellGold.Products.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand command) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productDto = await _mediator.Send(command);

            return StatusCode(201, productDto);
        }

        [HttpGet("{productId:guid}")]
        public async Task<IActionResult> GetProductById(Guid productId, CancellationToken cancellationToken)
        {

            var product = await _mediator.Send(new GetProductByIdQuery(productId));

            if (product == null)
                return NotFound($"Product with id {productId} not found.");

            return Ok(product);

        }

        [HttpPost("ProductProduceMessage")]            
        public async Task<IActionResult> ProductProduceMessage([FromBody] List<ProductRequest> produceMessageProducts)
        {
            if (produceMessageProducts == null || !produceMessageProducts.Any())
            {
                return BadRequest("List of products to import cannot be empty.");
            }

            // Dispara o Command via MediatR
            await _mediator.Send(new ProductProduceMessageCommand(produceMessageProducts));

            return Ok($"Product Produce Message of {produceMessageProducts.Count} products initiated. Processing in the background.");

        }

    }
}
