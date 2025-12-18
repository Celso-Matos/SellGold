using AutoMapper;
using MediatR;
using SellGold.Promotions.Application.Commands;
using SellGold.Promotions.Application.Contracts.DTOs.Responses;
using SellGold.Promotions.Application.Interfaces.Repositories;
using SellGold.Promotions.Domain.Entities;

namespace SellGold.Promotions.Application.Handlers.Promotions
{
    public class CreatePromotionHandler : IRequestHandler<CreatePromotionCommand, PromotionResponse>
    {
        private readonly IPromotionsRepository _promotionsRepository;
        private readonly IMapper _mapper;

        public CreatePromotionHandler(IPromotionsRepository promotionsRepository, IMapper mapper)
        {
            _promotionsRepository = promotionsRepository;
            _mapper = mapper;
        }

        public async Task<PromotionResponse> Handle(CreatePromotionCommand command, CancellationToken cancellationToken)
        {
            var promotion = _mapper.Map<Promotion>(command.createPromotionRequest);

            await _promotionsRepository.AddAsync(promotion, cancellationToken);

            var response = _mapper.Map<PromotionResponse>(promotion);

            return response;

        }
    }
}
