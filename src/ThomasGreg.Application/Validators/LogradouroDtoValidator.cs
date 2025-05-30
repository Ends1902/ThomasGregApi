using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThomasGreg.Application.Validators
{
    public class LogradouroDtoValidator : AbstractValidator<LogradouroDto>
    {
        public LogradouroDtoValidator() {

            RuleFor(c => c.Nome)
                    .NotEmpty().WithMessage("O nome do logradouro é obrigatório.")
                    .MaximumLength(100).WithMessage("O nome do logradouro deve ter no máximo 100 caracteres.");
            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("O numero do logradouro é obrigatório.")
                .EmailAddress().WithMessage("O número do logradouro do cliente deve ser válido");
            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage("O CEP do logradouro do cliente é obrigatório.")
                .MaximumLength(10).WithMessage("O CEP do logradouro do cliente deve ter no máximo 10 caracteres");
        }
    }
}
