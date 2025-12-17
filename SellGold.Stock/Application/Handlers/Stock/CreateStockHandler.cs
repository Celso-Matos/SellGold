using MediatR;
using SellGold.Stock.Application.Commands;
using SellGold.Stock.Application.Contracts.DTOs.Requests;
using SellGold.Stock.Application.Contracts.Mappers;
using SellGold.Stock.Application.Interfaces.Repositories;

namespace SellGold.Stock.Application.Handlers.Stock
{
    public class CreateStockHandler : IRequestHandler<CreateStockCommand, StockRequest>
    {
        private readonly IStockRepository _stockRepository;
        public CreateStockHandler(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        public async Task<StockRequest> Handle(CreateStockCommand command, CancellationToken cancellationToken)
        {
            var stock = StockProductMapper.ToEntity(command.CreateStockRequest);
            await _stockRepository.AddAsync(stock);
            var requestDto = StockProductMapper.ToRequest(stock);
            return requestDto;
        }
    }    
}
