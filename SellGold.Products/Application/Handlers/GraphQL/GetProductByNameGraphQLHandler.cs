using AutoMapper;
using MediatR;
using SellGold.Products.Application.Contracts.DTOs.Responses;
using SellGold.Products.Application.Interfaces.Repositories;
using SellGold.Products.Application.Queries.GraphQL;

namespace SellGold.Products.Application.Handlers.GraphQL
{
    public class GetProductByNameGraphQLHandler : IRequestHandler<GetProductByNameGraphQL, ProductResponse>
    {
        private readonly IProductsRepository _repository;
        private readonly IMapper _mapper;
        public GetProductByNameGraphQLHandler(IProductsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProductResponse> Handle(GetProductByNameGraphQL query, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByNameAsync(query.Name, cancellationToken);
            
            if (product == null)
            {
                return new ProductResponse
                {
                    Message = $"Produto com nome {query.Name} não encontrado.",
                    Success = false
                };
            }
            return _mapper.Map<ProductResponse>(product);
        } 
    }
}
