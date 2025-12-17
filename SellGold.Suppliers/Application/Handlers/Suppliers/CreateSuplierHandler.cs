using MediatR;
using SellGold.Suppliers.Application.Commands;
using SellGold.Suppliers.Application.Contracts.DTOs.Requests;
using SellGold.Suppliers.Application.Contracts.Mappers;
using SellGold.Suppliers.Application.Interfaces.Repositories;

namespace SellGold.Suppliers.Application.Handlers.Suppliers
{
    public class CreateSuplierHandler : IRequestHandler<CreateSupplierCommand, SupplierRequest>
    {
        private readonly ISupplierRepository _supplierRepository;

        public CreateSuplierHandler(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<SupplierRequest> Handle(CreateSupplierCommand command, CancellationToken cancellationToken)
        {
            var supplier = SupplierMapper.ToEntity(command.Request);
            await _supplierRepository.AddAsync(supplier);
            var requestDto = SupplierMapper.ToRequest(supplier);
            return requestDto;
        }
    }
}
