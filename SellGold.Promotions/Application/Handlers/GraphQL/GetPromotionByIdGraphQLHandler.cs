using AutoMapper;
using MediatR;
using SellGold.Promotions.Application.Commons;
using SellGold.Promotions.Application.Contracts.DTOs.Responses;
using SellGold.Promotions.Application.Interfaces.Repositories;
using SellGold.Promotions.Application.Queries.GraphQL;

namespace SellGold.Promotions.Application.Handlers.GraphQL
{
    public class GetPromotionByIdGraphQLHandler : IRequestHandler<GetPromotionByIdGraphQLQuery, PromotionResponse>
    {
        private readonly IPromotionsRepository _promotionsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetPromotionByIdGraphQLHandler(IPromotionsRepository promotionsRepository, IMapper mapper, ILogger<GetPromotionByIdGraphQLHandler> logger)
        {
            _promotionsRepository = promotionsRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PromotionResponse> Handle(GetPromotionByIdGraphQLQuery query, CancellationToken cancellationToken)
        {
            var promotion = await _promotionsRepository.GetByIdAsync(query.PromotionId, cancellationToken);
            if (promotion == null) 
            { 
                PromotionLogs.PromotionNotFound(_logger, query.PromotionId);
                throw new NotFoundException("Promotions", query.PromotionId) ;
            }

            var response = _mapper.Map<PromotionResponse>(promotion);

            return response;
        }

    }
}
