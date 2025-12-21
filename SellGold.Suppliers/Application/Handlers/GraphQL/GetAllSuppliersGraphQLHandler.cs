using AutoMapper;
using MediatR;
using SellGold.Suppliers.Application.Contracts.DTOs.Responses;
using SellGold.Suppliers.Application.Interfaces.Repositories;
using SellGold.Suppliers.Application.Queries.GraphQL;

namespace SellGold.Suppliers.Application.Handlers.GraphQL
{
    public class GetAllSuppliersGraphQLHandler : IRequestHandler<GetAllSuppliersGraphQLQuery, List<SupplierResponse>>
    {
        private readonly ISupplierRepository _repository;
        private readonly IMapper _mapper;
        public GetAllSuppliersGraphQLHandler(ISupplierRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<SupplierResponse>> Handle(GetAllSuppliersGraphQLQuery query, CancellationToken cancellationToken)
        {
            var suppliers = await _repository.GetAllAsync();
            return _mapper.Map<List<SupplierResponse>>(suppliers);
        }
    }
}
