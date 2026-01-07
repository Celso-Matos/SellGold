using FluentValidation;
using SellGold.Contracts.DTOs.Customers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SellGold.Utils
{
    public class ContactFluentValidator : AbstractValidator<CreateCustomerRequest>
    {
        public ContactFluentValidator()
        {
            // Validação de e-mail
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                .WithMessage("Formato de e-mail inválido");

            // Validação de telefone
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefone é obrigatório")
                .Matches(@"^\d{10,11}$")
                .WithMessage("Telefone deve ter 10 ou 11 dígitos")
                .Must(ValidarDDD).WithMessage("DDD inválido");

        }

        private bool ValidarDDD(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone) || telefone.Length < 2)
                return false;

            var ddd = int.Parse(telefone.Substring(0, 2));
            return ddd >= 11 && ddd <= 99;
        }

    }
}
