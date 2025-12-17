using MediatR;
using SellGold.Application.Suppliers.Queries;
using SellGold.Contracts.DTOs.Suppliers.Responses;
using SellGold.GraphQL.Suppliers.Services;

namespace SellGold.Application.Suppliers.Handlers
{
    public class ListSupplierHandler : IRequestHandler<ListSupplierQuery, List<SupplierResponse>>
    {
        private readonly ListSupplierGraphQLService _service;
        public ListSupplierHandler(ListSupplierGraphQLService service)
        {
            _service = service;
        }
        public async Task<List<SupplierResponse>> Handle(ListSupplierQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _service.GetAllSuppliersGraphQLAsync();
            return suppliers ?? new List<SupplierResponse>();
        }    
    }
}
