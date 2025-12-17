using MediatR;
using SellGold.Suppliers.Application.Contracts.DTOs.Responses;
using SellGold.Suppliers.Application.Contracts.Mappers;
using SellGold.Suppliers.Application.Interfaces.Repositories;
using SellGold.Suppliers.Application.Queries.GraphQL;

namespace SellGold.Suppliers.Application.Handlers.GraphQL
{
    public class GetAllSuppliersGraphQLHandler : IRequestHandler<GetAllSuppliersGraphQLQuery, List<SupplierResponse>>
    {
        private readonly ISupplierRepository _repository;
        public GetAllSuppliersGraphQLHandler(ISupplierRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<SupplierResponse>> Handle(GetAllSuppliersGraphQLQuery query, CancellationToken cancellationToken)
        {
            var suppliers = await _repository.GetAllAsync();
            return SupplierMapper.ToResponseList(suppliers);
        }
    }
}
