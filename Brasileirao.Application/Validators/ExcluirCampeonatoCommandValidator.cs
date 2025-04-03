using Brasileirao.Application.Commands.ExcluirCampeonato;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class ExcluirCampeonatoCommandValidator : AbstractValidator<ExcluirCampeonatoCommand>
{
    public ExcluirCampeonatoCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("O ID do campeonato nao pode ser nulo");
    }
}