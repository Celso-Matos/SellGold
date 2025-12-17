using AutoMapper;
using MediatR;
using SellGold.Customers.Application.Contracts.DTOs.Responses;
using SellGold.Customers.Application.Contracts.Mappers;
using SellGold.Customers.Application.Interfaces.Repositories;
using SellGold.Customers.Application.Queries.GraphQL;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;

namespace SellGold.Customers.Application.Handlers.GraphQL
{
    public class GetCustomertByIdGraphQLHandler : IRequestHandler<GetCustomerByIdGraphQLQuery, CustomerResponse>
    {
        private readonly ICustomersRepository _repository;
        private readonly IMapper _mapper;

        public GetCustomertByIdGraphQLHandler(ICustomersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomerResponse> Handle(GetCustomerByIdGraphQLQuery query, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(query.CustomerId);
            if (customer is null)
                throw new KeyNotFoundException("Cliente não encontrado.");

            var response = _mapper.Map<CustomerResponse>(customer);

            return response;
        }
    }
}
