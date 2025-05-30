using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Application.Validators
{
    public class ClienteDtoValidator : AbstractValidator<ClienteDto>
    {
        public ClienteDtoValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do cliente é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do cliente deve ter no máximo 100 caracteres.");
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O email do cliente é obrigatório.")
                .EmailAddress().WithMessage("O email do cliente deve ser um endereço de email válido.");
            RuleFor(c => c.Logotipo)
                .NotEmpty().WithMessage("O logotipo do cliente é obrigatório.")
                .MaximumLength(200).WithMessage("O logotipo do cliente deve ter no máximo 200 caracteres.");
        }
    }
}
