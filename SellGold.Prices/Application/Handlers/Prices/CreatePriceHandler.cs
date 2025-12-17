using MediatR;
using SellGold.Prices.Application.Commands;
using SellGold.Prices.Application.Contracts.DTOs.Requests;
using SellGold.Prices.Application.Contracts.Mappers;
using SellGold.Prices.Application.Interfaces.Repositories;

namespace SellGold.Prices.Application.Handlers.Prices
{
    public class CreatePriceHandler : IRequestHandler<CreatePriceCommand, PriceRequest>
    {
        private readonly IPricesRepository _pricesRepository;
        public CreatePriceHandler(IPricesRepository pricesRepository)
        {
            _pricesRepository = pricesRepository;
        }
        public async Task<PriceRequest> Handle(CreatePriceCommand command, CancellationToken cancellationToken)
        {
            var price = PriceMapper.ToEntity(command.CreatePriceRequest);
            await _pricesRepository.AddAsync(price);
            var requestDto = PriceMapper.ToRequest(price);
            return requestDto;
        }
    }
}
