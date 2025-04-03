using Brasileirao.Application.Commands.AdicionarCampeonato;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class AdicionarCampeonatoCommandValidator : AbstractValidator<AdicionarCampeonatoCommand>
{
    public AdicionarCampeonatoCommandValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O nome do campeonato nao pode ser vazio")
            .MaximumLength(255).WithMessage("O nome do campeonato nao pode ter mais de 255 caracteres");

        RuleFor(c => c.Ano)
            .NotEmpty().WithMessage("O ano nao pode ser vazio");
    }
}