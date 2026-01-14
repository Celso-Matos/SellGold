using MediatR;
using AutoMapper;
using SellGold.Products.Application.Contracts.DTOs.Responses;
using SellGold.Products.Application.Contracts.Mappers;
using SellGold.Products.Application.Interfaces.Repositories;
using SellGold.Products.Application.Queries.Products;

namespace SellGold.Products.Application.Handlers.Products
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IProductsRepository _repository;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProductResponse> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(query.ProductId);

            if (product == null)
                return null!;

            return _mapper.Map<ProductResponse>(product);
        }



    }
}
