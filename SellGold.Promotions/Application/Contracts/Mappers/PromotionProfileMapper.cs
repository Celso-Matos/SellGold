using AutoMapper;
using SellGold.Promotions.Domain.Entities;
using SellGold.Promotions.Application.Contracts.DTOs.Responses;

namespace SellGold.Promotions.Application.Contracts.Mappers
{
    public class PromotionProfileMapper : Profile
    {
        public PromotionProfileMapper()
        {
            CreateMap<Promotion, PromotionResponse>()
                .ForMember(
                    dest => dest.IsActive,
                    opt => opt.MapFrom(src => src.IsActive(DateTime.UtcNow)));
        }
    }
}
