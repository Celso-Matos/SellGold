using AutoMapper;
using MediatR;
using SellGold.Customers.Application.Contracts.DTOs.Responses;
using SellGold.Customers.Application.Contracts.Mappers;
using SellGold.Customers.Application.Interfaces.Repositories;
using SellGold.Customers.Application.Queries.GraphQL;

namespace SellGold.Customers.Application.Handlers.GraphQL
{
    public class GetAllCustomersGraphQLHandler : IRequestHandler<GetAllCustomersGraphQLQuery, List<CustomerResponse>>
    {
        private readonly ICustomersRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCustomersGraphQLHandler(ICustomersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CustomerResponse>> Handle(GetAllCustomersGraphQLQuery query, CancellationToken cancellationToken)
        {
            var customers = await _repository.GetAllAsync();
            return _mapper.Map<List<CustomerResponse>>(customers);

        }
    }
}
