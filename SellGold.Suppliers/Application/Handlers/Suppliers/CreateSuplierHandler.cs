using AutoMapper;
using MediatR;
using SellGold.Suppliers.Application.Commands;
using SellGold.Suppliers.Application.Contracts.DTOs.Responses;
using SellGold.Suppliers.Application.Interfaces.Repositories;
using SellGold.Suppliers.Domain.Entities;

namespace SellGold.Suppliers.Application.Handlers.Suppliers
{
    public class CreateSuplierHandler : IRequestHandler<CreateSupplierCommand, SupplierResponse>
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public CreateSuplierHandler(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<SupplierResponse> Handle(CreateSupplierCommand command, CancellationToken cancellationToken)
        {
            // Converte o DTO de Request para entidade de domínio
            var supplier = _mapper.Map<Supplier>(command.createSupplierRequest);

            // Persiste no repositório
            await _supplierRepository.AddAsync(supplier);

            // Converte a entidade para DTO de Response
            var response = _mapper.Map<SupplierResponse>(supplier);

            return response;
        }
    }
}
