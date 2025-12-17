using Azure.Core;
using Humanizer;
using SellGold.Prices.Application.Contracts.DTOs.Requests;
using SellGold.Prices.Application.Contracts.DTOs.Responses;
using SellGold.Prices.Domain.Entities;
using SellGold.Prices.Domain.ValueObject;
using static Grpc.Core.Metadata;
namespace SellGold.Prices.Application.Contracts.Mappers
{
    public static class PriceMapper
    {
        // Converte DTO -> Entidade
        public static Price ToEntity(PriceRequest request)
        {
            return new Price
            {
                BasePrice = new PriceMoney
                {
                    Amount = request.BasePriceAmount,
                    Currency = request.BasePriceCurrency
                },
                Discounts = request.Discounts?.Select(d => new PriceDiscount
                {
                    PriceDiscountId = d.PriceDiscountId,
                    Type = (DiscountType)d.Type,
                    Value = d.Value,
                    StartDate = d.StartDate,
                    EndDate = d.EndDate,
                    PriceId = d.PriceId
                }).ToList() ?? new List<PriceDiscount>(),                
                Policies = request.Policies?.Select(p => new PricePolicy
                {
                    PricePolicyId = p.PricePolicyId,
                    Strategy = (Strategy)p.Strategy,
                    Rules = p.Rules,
                }).ToList() ?? new List<PricePolicy>(),
                Taxes = request.Taxes?.Select(t => new PriceTax
                {
                    PriceTaxId = t.PriceTaxId,
                    Name = t.Name,
                    Rate = t.Rate,
                    PriceId = t.PriceId
                }).ToList() ?? new List<PriceTax>()
            };
        }
        // Converte Entidade -> DTO (Request)
        public static PriceRequest ToRequest(Price price)
        {
            return new PriceRequest
            {
                BasePriceAmount = price.BasePrice.Amount,
                BasePriceCurrency = price.BasePrice.Currency,
                Discounts = price.Discounts.Select(d => new PriceDiscountRequest
                {
                    PriceDiscountId = d.PriceDiscountId,
                    Type = (int)d.Type,
                    Value = d.Value,
                    StartDate = d.StartDate,
                    EndDate = d.EndDate,
                    PriceId = d.PriceId
                }).ToList() ?? new List<PriceDiscountRequest>(),
                Policies = price.Policies.Select(p => new PricePolicyRequest
                {
                    PricePolicyId = p.PricePolicyId,
                    Strategy = (int)p.Strategy,
                    Rules = p.Rules,
                }).ToList() ?? new List<PricePolicyRequest>(),
                Taxes = price.Taxes?.Select(t => new PriceTaxRequest
                {
                    PriceTaxId = t.PriceTaxId,
                    Name = t.Name,
                    Rate = t.Rate,
                    PriceId = t.PriceId
                }).ToList() ?? new List<PriceTaxRequest>()

            };
        }
        // Converte Entidade -> DTO (Response)
        public static PriceResponse ToResponse(Price price)
        {
            return new PriceResponse
            {
                PriceId = price.PriceId,
                BasePriceAmount = price.BasePrice.Amount,
                BasePriceCurrency = price.BasePrice.Currency,

                Discounts = price.Discounts.Select(d => new PriceDiscountResponse
                {
                    PriceDiscountId = d.PriceDiscountId,
                    Type = (int)d.Type,
                    Value = d.Value,
                    StartDate = d.StartDate,
                    EndDate = d.EndDate,
                    PriceId = d.PriceId
                }).ToList() ?? new List<PriceDiscountResponse>(),
                Policies = price.Policies.Select(p => new PricePolicyResponse
                {
                    PricePolicyId = p.PricePolicyId,
                    Strategy = (int)p.Strategy,
                    Rules = p.Rules
                }).ToList() ?? new List<PricePolicyResponse>(),
                Taxes = price.Taxes?.Select(t => new PriceTaxResponse
                {
                    PriceTaxId = t.PriceTaxId,
                    Name = t.Name,
                    Rate = t.Rate,
                    PriceId = t.PriceId
                }).ToList() ?? new List<PriceTaxResponse>(),
                IsActive = price.IsActive,
            };
        }

        // Converte lista de Entidades -> lista de DTOs (Response)
        public static List<PriceResponse> ToResponseList(IEnumerable<Price> prices)
        {
            return prices.Select(price => ToResponse(price)).ToList();
        }
    }
}
