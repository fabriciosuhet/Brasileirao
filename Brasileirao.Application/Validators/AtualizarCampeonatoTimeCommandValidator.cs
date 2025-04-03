using Brasileirao.Application.Commands.AtualizarCampeonatoTime;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class AtualizarCampeonatoTimeCommandValidator : AbstractValidator<AtualizarCampeonatoTimeCommand>
{
    public AtualizarCampeonatoTimeCommandValidator()
    {
        RuleFor(ct => ct.Id)
            .NotEmpty().WithMessage("O ID do campeonato time nao pode ser vazio");
        
        RuleFor(ct => ct.CampeonatoId)
            .NotEmpty().WithMessage("O ID do campeonato nao pode ser vazio");

        RuleFor(ct => ct.TimeId)
            .NotEmpty().WithMessage("O ID do time nao pode ser vazio");
    }
}