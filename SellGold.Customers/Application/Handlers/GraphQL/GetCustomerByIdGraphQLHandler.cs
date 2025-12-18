using AutoMapper;
using MediatR;
using SellGold.Customers.Application.Commons;
using SellGold.Customers.Application.Contracts.DTOs.Responses;
using SellGold.Customers.Application.Interfaces.Repositories;
using SellGold.Customers.Application.Queries.GraphQL;
using SellGold.Orders.Application.Commons;

namespace SellGold.Customers.Application.Handlers.GraphQL
{
    public class GetCustomerByIdGraphQLHandler : IRequestHandler<GetCustomerByIdGraphQLQuery, CustomerResponse>
    {
        private readonly ICustomersRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetCustomerByIdGraphQLHandler(ICustomersRepository repository, IMapper mapper, ILogger logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CustomerResponse> Handle(GetCustomerByIdGraphQLQuery query, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(query.CustomerId);
            if (customer is null)
            {
                CustomerLogs.CustomerNotFound(_logger, query.CustomerId);
                throw new NotFoundException("Customer", query.CustomerId);
            }               

            var response = _mapper.Map<CustomerResponse>(customer);

            return response;
        }
    }
}
