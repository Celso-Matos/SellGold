using AutoMapper;
using SellGold.Promotions.Domain.Entities;
using SellGold.Promotions.Application.Contracts.DTOs.Responses;

namespace SellGold.Promotions.Application.Contracts.Mappers
{
    public sealed class LoyaltyAccountProfileMapper : Profile
    {
        public LoyaltyAccountProfileMapper()
        {
            CreateMap<LoyaltyAccount, LoyaltyAccountResponse>();
        }
    }
}
