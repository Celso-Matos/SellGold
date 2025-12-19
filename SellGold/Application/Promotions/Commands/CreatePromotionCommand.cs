using MediatR;
using SellGold.Contracts.DTOs.Promotions.Requests;

namespace SellGold.Application.Promotions.Commands
{
    public record CreatePromotionCommand(CreatePromotionRequest createPromotionRequest) : IRequest<bool>;
}
