using Brasileirao.Application.Commands.AdicionarCampeonatoTime;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class AdicionarCampeonatoTimeCommandValidator : AbstractValidator<AdicionarCampeonatoTimeCommand>
{
    public AdicionarCampeonatoTimeCommandValidator()
    {
        RuleFor(ct => ct.CampeonatoId)
            .NotEmpty().WithMessage("O ID do campeonato nao pode ser nulo");
        
        RuleFor(ct => ct.TimeId)
            .NotEmpty().WithMessage("O ID do time nao pode ser nulo");
    }
}