using AutoMapper;
using MediatR;
using SellGold.Payments.Application.Commands;
using SellGold.Payments.Application.Contracts.DTOs.Responses;
using SellGold.Payments.Application.Interfaces.Repositories;
using SellGold.Payments.Domain.Entities;

namespace SellGold.Payments.Application.Handlers.Payments
{
    public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommand, PaymentResponse>
    {
        private readonly IPaymentsRepository _paymentsRepository;
        private readonly IMapper _mapper;
        public CreatePaymentHandler(IPaymentsRepository paymentsRepository, IMapper mapper)
        {
            _paymentsRepository = paymentsRepository;
            _mapper = mapper;
        }
        public async Task<PaymentResponse> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
        {
            // Converte o DTO de Request para entidade de domínio
            var payment = _mapper.Map<Payment>(command.createPaymentRequest);
            // Persiste no repositório
            await _paymentsRepository.AddAsync(payment);
            // Converte a entidade para DTO de Response
            var response = _mapper.Map<PaymentResponse>(payment);
            return response;
        }
    }
}
