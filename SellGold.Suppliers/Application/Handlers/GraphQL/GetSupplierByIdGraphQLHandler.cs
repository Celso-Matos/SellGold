using MediatR;
using SellGold.Suppliers.Application.Contracts.DTOs.Responses;
using SellGold.Suppliers.Application.Contracts.Mappers;
using SellGold.Suppliers.Application.Interfaces.Repositories;
using SellGold.Suppliers.Application.Queries.GraphQL;

namespace SellGold.Suppliers.Application.Handlers.GraphQL
{
    public class GetSupplierByIdGraphQLHandler : IRequestHandler<GetSupplierByIdGraphQLQuery, SupplierResponse>
    {
        private readonly ISupplierRepository _repository;
        public GetSupplierByIdGraphQLHandler(ISupplierRepository repository)
        {
            _repository = repository;
        }
        public async Task<SupplierResponse> Handle(GetSupplierByIdGraphQLQuery query, CancellationToken cancellationToken)
        {
            var supplier = await _repository.GetByIdAsync(query.SupplierId);
            return supplier == null ? null! : SupplierMapper.ToResponse(supplier);
        }   
    
    }
}
