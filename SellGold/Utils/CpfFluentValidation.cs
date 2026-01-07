using FluentValidation;
using SellGold.Contracts.DTOs.Payments.Requests;

namespace SellGold.Utils
{
    public class CpfFluentValidation : AbstractValidator<PaymentCpfRequest>
    {
        public CpfFluentValidation()
        {
            RuleFor(x => x.CPF)
                .NotEmpty().WithMessage("CPF é obrigatório")
                .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")
                    .WithMessage("CPF deve estar no formato XXX.XXX.XXX-XX")
                .Must(CpfValidator.Validar)
                    .WithMessage("CPF inválido: dígitos verificadores não conferem.");
        }
    }
}
