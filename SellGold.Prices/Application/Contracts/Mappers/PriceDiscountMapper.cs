using SellGold.Prices.Application.Contracts.DTOs.Requests;
using SellGold.Prices.Application.Contracts.DTOs.Responses;
using SellGold.Prices.Domain.Entities;

namespace SellGold.Prices.Application.Contracts.Mappers
{
    public static class PriceDiscountMapper
    {
        // Converte DTO -> Entidade
        public static PriceDiscount ToEntity(PriceDiscountRequest request)
        {
            return new PriceDiscount
            {
                PriceDiscountId = request.PriceDiscountId,
                Type = (DiscountType)request.Type,
                Value = request.Value,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                PriceId = request.PriceId
            };
        }

        // Converte Entidade -> DTO (Request)
        public static PriceDiscountRequest ToRequest(PriceDiscount discount)
        {
            return new PriceDiscountRequest
            {
                PriceDiscountId = discount.PriceDiscountId,
                Type = (int)discount.Type,
                Value = discount.Value,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                PriceId = discount.PriceId
            };
        }

        // Converte Entidade -> DTO (Response)
        public static PriceDiscountResponse ToResponse(PriceDiscount discount)
        {
            return new PriceDiscountResponse
            {
                PriceDiscountId = discount.PriceDiscountId,
                Type = (int)discount.Type,
                Value = discount.Value,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                PriceId = discount.PriceId
            };
        }

        
        // Converte lista de Entidades -> lista de DTOs
        public static List<PriceDiscountResponse> ToResponseList(List<PriceDiscount> discounts)
        {
            return discounts.Select(d => ToResponse(d)).ToList();
        }
    }
}
