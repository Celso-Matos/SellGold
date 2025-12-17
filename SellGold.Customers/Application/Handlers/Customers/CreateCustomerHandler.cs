using AutoMapper;
using MediatR;
using SellGold.Customers.Application.Commands;
using SellGold.Customers.Application.Contracts.DTOs.Responses;
using SellGold.Customers.Application.Interfaces.Repositories;
using SellGold.Customers.Domain.Entities;

namespace SellGold.Customers.Application.Handlers.Customers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;
        public CreateCustomerHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;

        }
        public async Task<CustomerResponse> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            // Converte o DTO de Request para entidade de domínio
            var customer = _mapper.Map<Customer>(command.CreateCustomerRequest);

            // Persiste no repositório
            await _customersRepository.AddAsync(customer);

            // Converte a entidade para DTO de Response
            var response = _mapper.Map<CustomerResponse>(customer);

            return response;

        }

    }
}
