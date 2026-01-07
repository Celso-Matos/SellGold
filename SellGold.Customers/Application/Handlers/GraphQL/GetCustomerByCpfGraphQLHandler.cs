using AutoMapper;
using MediatR;
using SellGold.Customers.Application.Contracts.DTOs.Responses;
using SellGold.Customers.Application.Interfaces.Repositories;
using SellGold.Customers.Application.Queries.GraphQL;

namespace SellGold.Customers.Application.Handlers.GraphQL
{
    public class GetCustomerByCpfGraphQLHandler : IRequestHandler<GetCustomerByCpfGraphQLQuery, CustomerResponse>
    {
        private readonly ICustomersRepository _repository;
        private readonly IMapper _mapper;
        public GetCustomerByCpfGraphQLHandler(ICustomersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CustomerResponse> Handle(GetCustomerByCpfGraphQLQuery query, CancellationToken cancellationToken)
        {
            var customer =  await _repository.GetByCpfAsync(query.Cpf, cancellationToken);
            return _mapper.Map<CustomerResponse>(customer);
        }   
    
    }
}
