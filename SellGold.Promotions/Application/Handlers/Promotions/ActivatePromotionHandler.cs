using AutoMapper;
using MediatR;
using SellGold.Promotions.Application.Commands;
using SellGold.Promotions.Application.Commons;
using SellGold.Promotions.Application.Contracts.DTOs.Responses;
using SellGold.Promotions.Application.Interfaces.Repositories;

namespace SellGold.Promotions.Application.Handlers.Promotions
{
    public class ActivatePromotionHandler : IRequestHandler<ActivatePromotionCommand, PromotionResponse>
    {
        private readonly IPromotionsRepository _promotionsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ActivatePromotionHandler> _logger;

        public ActivatePromotionHandler(IPromotionsRepository promotionsRepository,
                                        IMapper mapper,
                                        ILogger<ActivatePromotionHandler> logger)
        {
            _promotionsRepository = promotionsRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<PromotionResponse> Handle(ActivatePromotionCommand command, CancellationToken cancellationToken)
        {
            var promotion = await _promotionsRepository.GetByIdAsync(command.PromotionId, cancellationToken);
            if (promotion == null) 
            { 
                PromotionLogs.PromotionNotFound(_logger, command.PromotionId);
                throw new NotFoundException("Promotions", command.PromotionId);            
            }
            if(!promotion.IsActive(DateTime.UtcNow))
            {
                promotion.IsActive(DateTime.UtcNow);
            }
            return _mapper.Map<PromotionResponse>(promotion);
        }
    }
}
