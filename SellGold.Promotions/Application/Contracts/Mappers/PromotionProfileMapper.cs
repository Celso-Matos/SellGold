using AutoMapper;
using SellGold.Promotions.Domain.Entities;
using SellGold.Promotions.Application.Contracts.DTOs.Requests;
using SellGold.Promotions.Application.Contracts.DTOs.Responses;

namespace SellGold.Promotions.Application.Contracts.Mappers
{
    public class PromotionProfileMapper : Profile
    {
        public PromotionProfileMapper()
        {
            CreateMap<CreatePromotionRequest, Promotion>()
                .ConstructUsing(src =>
                    Promotion.Create(
                        src.Name,
                        src.StartDate,
                        src.EndDate,
                        src.DiscountPercentage,
                        src.Description
                    )
                );

            CreateMap<Promotion, PromotionResponse>()
                .ForMember(
                    dest => dest.PromotionId,
                    opt => opt.MapFrom(src => src.PromotionId))
                .ForMember(
                    dest => dest.IsActive,
                    opt => opt.MapFrom(src => src.IsActive(DateTime.UtcNow)))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(
                    dest => dest.StartDate,
                    opt => opt.MapFrom(src => src.StartDate))
                .ForMember(
                    dest => dest.EndDate,
                    opt => opt.MapFrom(src => src.EndDate))
                .ForMember(
                    dest => dest.DiscountPercentage,
                    opt => opt.MapFrom(src => src.DiscountPercentage))
                .ForMember(
                    dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => src.CreatedAt));
        }        
    }
}
