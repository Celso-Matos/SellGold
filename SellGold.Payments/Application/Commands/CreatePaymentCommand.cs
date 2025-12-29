using MediatR;
using SellGold.Payments.Application.Contracts.DTOs.Requests;
using SellGold.Payments.Application.Contracts.DTOs.Responses;

namespace SellGold.Payments.Application.Commands
{
    public record CreatePaymentCommand(CreatePaymentRequest createPaymentRequest) : IRequest<PaymentResponse>;
}
