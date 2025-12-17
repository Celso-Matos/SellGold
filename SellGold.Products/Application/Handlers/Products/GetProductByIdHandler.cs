using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Responses;
using SellGold.Products.Application.Contracts.Mappers;
using SellGold.Products.Application.Interfaces.Repositories;
using SellGold.Products.Application.Queries.Products;

namespace SellGold.Products.Application.Handlers.Products
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IProductsRepository _repository;

        public GetProductByIdHandler(IProductsRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductResponse> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(query.ProductId);

            if (product == null)
                return null!;

            return ProductMapper.ToResponse(product);
        }



    }
}
