using AutoMapper;
using MediatR;
using SellGold.Products.Application.Commands;
using SellGold.Products.Application.Contracts.DTOs.Requests;
using SellGold.Products.Application.Contracts.Mappers;
using SellGold.Products.Application.Interfaces.Repositories;
using SellGold.Products.Domain.Entities;

namespace SellGold.Products.Application.Handlers.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductRequest>
    {
        private readonly IProductsRepository _productRepository;
        private readonly IMapper _mapper;
        public CreateProductHandler(IProductsRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<CreateProductRequest> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(command.CreateProductRequest);

            await _productRepository.AddAsync(product);

            var requestDto = _mapper.Map<CreateProductRequest>(product);

            return requestDto;

        }
    
    }
}
