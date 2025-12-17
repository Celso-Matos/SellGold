using AutoMapper;
using MediatR;
using SellGold.Customers.Application.Contracts.DTOs.Responses;
using SellGold.Customers.Application.Contracts.Mappers;
using SellGold.Customers.Application.Interfaces.Repositories;
using SellGold.Customers.Application.Queries.Customers;

namespace SellGold.Customers.Application.Handlers.Customers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResponse>
    {
        private readonly ICustomersRepository _repository;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(ICustomersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<CustomerResponse> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(query.CustomerId);
            if (customer == null)
                return null!;
            // Converte Entidade -> DTO de Response
            var response = _mapper.Map<CustomerResponse>(customer);

            // Retorna o DTO de Response
            return response;
        }
    }
}
