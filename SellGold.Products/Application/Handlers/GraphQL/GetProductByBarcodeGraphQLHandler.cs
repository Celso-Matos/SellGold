using AutoMapper;
using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Responses;
using SellGold.Products.Application.Interfaces.Repositories;
using SellGold.Products.Application.Queries.GraphQL;

namespace SellGold.Products.Application.Handlers.GraphQL
{
    public class GetProductByBarcodeGraphQLHandler : IRequestHandler<GetProductByBarcodeGraphQLQuery, ProductResponse>
    {
        private readonly IProductsRepository _repository;
        private readonly IMapper _mapper;
        public GetProductByBarcodeGraphQLHandler(IProductsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProductResponse> Handle(GetProductByBarcodeGraphQLQuery query, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByBarcodeAsync(query.Barcode, cancellationToken);
            if (product == null)
            {
                return new ProductResponse
                {
                    Message = $"Código de barras {query.Barcode} não encontrado.",
                    Success = false
                };
            }
            return _mapper.Map<ProductResponse>(product);
        }
    }
}
