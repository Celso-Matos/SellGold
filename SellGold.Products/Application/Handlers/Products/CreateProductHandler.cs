using MediatR;
using SellGold.Products.Application.Commands;
using SellGold.Products.Application.Contracts.DTOs.Requests;
using SellGold.Products.Application.Contracts.Mappers;
using SellGold.Products.Application.Interfaces.Repositories;

namespace SellGold.Products.Application.Handlers.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductRequest>
    {
        private readonly IProductsRepository _productRepository;
        public CreateProductHandler(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductRequest> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = ProductMapper.ToEntity(command.CreateProductRequest);

            await _productRepository.AddAsync(product);

            var requestDto = ProductMapper.ToRequest(product);

            return requestDto;

        }
    
    }
}
