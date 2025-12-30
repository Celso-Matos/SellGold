using MediatR;
using SellGold.Contracts.DTOs.Payments.Requests;

namespace SellGold.Application.Payments.Commands
{
    public record CreatePaymentCommand(CreatePaymentRequest createPaymentRequest) : IRequest<bool>;
}
