using AutoMapper;
using MediatR;
using SellGold.Promotions.Application.Contracts.DTOs.Responses;
using SellGold.Promotions.Application.Interfaces.Repositories;
using SellGold.Promotions.Application.Queries.GraphQL;

namespace SellGold.Promotions.Application.Handlers.GraphQL
{
    public class GetAllPromotionsGraphQLHandler : IRequestHandler<GetAllPromotionGraphQLQuery, List<PromotionResponse>>
    {
        private readonly IPromotionsRepository _promotionsRepository;
        private readonly IMapper _mapper;

        public GetAllPromotionsGraphQLHandler(IPromotionsRepository promotionsRepository, IMapper mapper)
        {
            _promotionsRepository = promotionsRepository;
            _mapper = mapper;
        }

        public async Task<List<PromotionResponse>> Handle(GetAllPromotionGraphQLQuery query, CancellationToken cancellationToken)
        {
            var promotion = await _promotionsRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<PromotionResponse>>(promotion);
        
        }
    }
}
