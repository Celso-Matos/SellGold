using AutoMapper;
using MediatR;
using SellGold.Prices.Application.Commands;
using SellGold.Prices.Application.Contracts.DTOs.Requests;
using SellGold.Prices.Application.Interfaces.Repositories;
using SellGold.Prices.Domain.Entities;

namespace SellGold.Prices.Application.Handlers.Prices
{
    public class CreatePriceHandler : IRequestHandler<CreatePriceCommand, PriceRequest>
    {
        private readonly IPricesRepository _pricesRepository;
        private readonly IMapper _mapper;
        public CreatePriceHandler(IPricesRepository pricesRepository, IMapper mapper)
        {
            _pricesRepository = pricesRepository;
            _mapper = mapper;
        }
        public async Task<PriceRequest> Handle(CreatePriceCommand command, CancellationToken cancellationToken)
        {
            var price = _mapper.Map<Price>(command.CreatePriceRequest);
            await _pricesRepository.AddAsync(price);
            var requestDto = _mapper.Map<PriceRequest>(price);
            return requestDto;
        }
    }
}
