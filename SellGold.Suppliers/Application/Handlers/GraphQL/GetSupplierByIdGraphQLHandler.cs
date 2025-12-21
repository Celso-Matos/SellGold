using AutoMapper;
using MediatR;
using SellGold.Suppliers.Application.Commons;
using SellGold.Suppliers.Application.Contracts.DTOs.Responses;
using SellGold.Suppliers.Application.Interfaces.Repositories;
using SellGold.Suppliers.Application.Queries.GraphQL;


namespace SellGold.Suppliers.Application.Handlers.GraphQL
{
    public class GetSupplierByIdGraphQLHandler : IRequestHandler<GetSupplierByIdGraphQLQuery, SupplierResponse>
    {
        private readonly ISupplierRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetSupplierByIdGraphQLHandler(ISupplierRepository repository, IMapper mapper, ILogger<GetSupplierByIdGraphQLHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<SupplierResponse> Handle(GetSupplierByIdGraphQLQuery query, CancellationToken cancellationToken)
        {
            var supplier = await _repository.GetByIdAsync(query.SupplierId);
            if (supplier == null)
            {
                SupplierLogs.SupplierNotFound(_logger, query.SupplierId);
                throw new NotFoundException("Suppliers", query.SupplierId);
            }
            var response = _mapper.Map<SupplierResponse>(supplier);

            return response;
        }   
    
    }
}
