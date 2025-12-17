using SellGold.Prices.Application.Contracts.DTOs.Requests;
using SellGold.Prices.Application.Contracts.DTOs.Responses;
using SellGold.Prices.Domain.Entities;

namespace SellGold.Prices.Application.Contracts.Mappers
{
    public static class PriceTaxMapper
    {
        // Converte DTO -> Entidade
        public static PriceTax ToEntity(PriceTaxRequest request)
        {
            return new PriceTax
            {
                PriceTaxId = request.PriceTaxId,
                Name = request.Name,
                Rate = request.Rate,
                PriceId = request.PriceId
            };
        }
        // Converte Entidade -> DTO (Request)
        public static PriceTaxRequest ToRequest(PriceTax tax)
        {
            return new PriceTaxRequest
            {
                PriceTaxId = tax.PriceTaxId,
                Name = tax.Name,
                Rate = tax.Rate,
                PriceId = tax.PriceId
            };
        }
        // Converte Entidade -> DTO (Response)
        public static PriceTaxResponse ToResponse(PriceTax tax)
        {
            return new PriceTaxResponse
            {
                PriceTaxId = tax.PriceTaxId,
                Name = tax.Name,
                Rate = tax.Rate,
                PriceId = tax.PriceId
            };
        }
    }
}
