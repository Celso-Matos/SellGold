using AutoMapper;
using SellGold.Prices.Application.Contracts.DTOs.Requests;
using SellGold.Prices.Application.Contracts.DTOs.Responses;
using SellGold.Prices.Domain.Entities;

namespace SellGold.Prices.Application.Contracts.Mappers
{
    public class PriceProductsProfileMapper : Profile
    {
        public PriceProductsProfileMapper()
        {
            // Request → Domain
            CreateMap<PriceProducstRequest, PriceProduct>()
                .ConstructUsing(dto => new PriceProduct(
                    dto.ProductId,
                    dto.PriceId,
                    dto.EffectiveDate,
                    dto.ExpirationDate,
                    dto.IsActive
                ));

            // Domain → Response
            CreateMap<PriceProduct, PriceProductsResponse>()
                .ForMember(dest => dest.PriceProductId, opt => opt.MapFrom(src => src.PriceProductId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.PriceId, opt => opt.MapFrom(src => src.PriceId))
                .ForMember(dest => dest.EffectiveDate, opt => opt.MapFrom(src => src.EffectiveDate))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));
        }

    }
}
