using Brasileirao.Application.Commands.AtualizarCampeonato;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class AtualizarCampeonatoCommandValidator : AbstractValidator<AtualizarCampeonatoCommand>
{
    public AtualizarCampeonatoCommandValidator()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O nome do campeonato nao pode ser nulo");
        
        RuleFor(c => c.Id)
            .NotEmpty().WithMessage("O ID do campeonato nao pode ser nulo");
    }
}