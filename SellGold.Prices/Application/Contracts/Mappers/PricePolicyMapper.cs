using SellGold.Prices.Application.Contracts.DTOs.Requests;
using SellGold.Prices.Application.Contracts.DTOs.Responses;
using SellGold.Prices.Domain.Entities;

namespace SellGold.Prices.Application.Contracts.Mappers
{
    public static class PricePolicyMapper
    {
        // Converte DTO -> Entidade
        public static PricePolicy ToEntity(PricePolicyRequest request)
        {
            return new PricePolicy
            {
                PricePolicyId = request.PricePolicyId,
                Strategy = (Strategy)request.Strategy,
                Rules = request.Rules,
            };
        }
        // Converte Entidade -> DTO (Request)
        public static PricePolicyRequest ToRequest(PricePolicy policy)
        {
            return new PricePolicyRequest
            {
                PricePolicyId = policy.PricePolicyId,
                Strategy = (int)policy.Strategy,
                Rules = policy.Rules,
            };
        }
        // Converte Entidade -> DTO (Response)
        public static PricePolicyResponse ToResponse(PricePolicy policy)
        {
            return new PricePolicyResponse
            {
                PricePolicyId = policy.PricePolicyId,
                Strategy = (int)policy.Strategy,
                Rules = policy.Rules,
            };
        }
    }
}
