using MediatR;
using SellGold.Promotions.Application.Contracts.DTOs.Requests;
using SellGold.Promotions.Application.Contracts.DTOs.Responses;

namespace SellGold.Promotions.Application.Commands
{
    public record CreatePromotionCommand(CreatePromotionRequest createPromotionRequest) : IRequest<PromotionResponse>;
    
}
