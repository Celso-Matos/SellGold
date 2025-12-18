using AutoMapper;
using SellGold.Promotions.Domain.Entities;
using SellGold.Promotions.Application.Contracts.DTOs.Responses;

namespace SellGold.Promotions.Application.Contracts.Mappers
{
    public class CashbackAccountProfileMapper : Profile
    {
        public CashbackAccountProfileMapper()
        {
            CreateMap<CashbackAccount, CashbackAccountResponse>();
        }
    }
}
