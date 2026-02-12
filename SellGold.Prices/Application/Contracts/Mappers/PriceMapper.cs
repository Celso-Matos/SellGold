using AutoMapper;
using SellGold.Prices.Application.Contracts.DTOs.Requests;
using SellGold.Prices.Application.Contracts.DTOs.Responses;
using SellGold.Prices.Domain.Entities;
using SellGold.Prices.Domain.ValueObject;

namespace SellGold.Prices.Application.Contracts.Mappers
{
    public class PriceProfileMapper : Profile
    {
        public PriceProfileMapper()
        {
            // Request → Domain
            CreateMap<PriceRequest, Price>()
                .ForMember(dest => dest.BasePrice, opt => opt.MapFrom(src => new PriceMoney
                {
                    Amount = src.BasePriceAmount,
                    Currency = src.BasePriceCurrency
                }))
                .ForMember(dest => dest.PriceProducts, opt => opt.MapFrom(src => src.PriceProducts))
                .ForMember(dest => dest.Discounts, opt => opt.MapFrom(src => src.Discounts))
                .ForMember(dest => dest.Policies, opt => opt.MapFrom(src => src.Policies))
                .ForMember(dest => dest.Taxes, opt => opt.MapFrom(src => src.Taxes));

            // Domain → Request
            CreateMap<Price, PriceRequest>()
                .ForMember(dest => dest.BasePriceAmount, opt => opt.MapFrom(src => src.BasePrice.Amount))
                .ForMember(dest => dest.BasePriceCurrency, opt => opt.MapFrom(src => src.BasePrice.Currency))
                .ForMember(dest => dest.PriceProducts, opt => opt.MapFrom(src => src.PriceProducts))
                .ForMember(dest => dest.Discounts, opt => opt.MapFrom(src => src.Discounts))
                .ForMember(dest => dest.Policies, opt => opt.MapFrom(src => src.Policies))
                .ForMember(dest => dest.Taxes, opt => opt.MapFrom(src => src.Taxes));

            // Domain → Response
            CreateMap<Price, PriceResponse>()
                .ForMember(dest => dest.PriceId, opt => opt.MapFrom(src => src.PriceId))
                .ForMember(dest => dest.BasePriceAmount, opt => opt.MapFrom(src => src.BasePrice.Amount))
                .ForMember(dest => dest.BasePriceCurrency, opt => opt.MapFrom(src => src.BasePrice.Currency))
                .ForMember(dest => dest.PriceProducts, opt => opt.MapFrom(src => src.PriceProducts))
                .ForMember(dest => dest.Discounts, opt => opt.MapFrom(src => src.Discounts))
                .ForMember(dest => dest.Policies, opt => opt.MapFrom(src => src.Policies))
                .ForMember(dest => dest.Taxes, opt => opt.MapFrom(src => src.Taxes))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));

            // Sub-mapeamentos (internos)
            CreateMap<PriceProducstRequest, PriceProduct>();
            CreateMap<PriceProduct, PriceProducstRequest>();
            CreateMap<PriceProduct, PriceProductsResponse>();

            CreateMap<PriceDiscountRequest, PriceDiscount>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (DiscountType)src.Type));
            CreateMap<PriceDiscount, PriceDiscountRequest>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type));
            CreateMap<PriceDiscount, PriceDiscountResponse>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type));

            CreateMap<PricePolicyRequest, PricePolicy>()
                .ForMember(dest => dest.Strategy, opt => opt.MapFrom(src => (Strategy)src.Strategy));
            CreateMap<PricePolicy, PricePolicyRequest>()
                .ForMember(dest => dest.Strategy, opt => opt.MapFrom(src => (int)src.Strategy));
            CreateMap<PricePolicy, PricePolicyResponse>()
                .ForMember(dest => dest.Strategy, opt => opt.MapFrom(src => (int)src.Strategy));

            CreateMap<PriceTaxRequest, PriceTax>();
            CreateMap<PriceTax, PriceTaxRequest>();
            CreateMap<PriceTax, PriceTaxResponse>();
        }
    }
}