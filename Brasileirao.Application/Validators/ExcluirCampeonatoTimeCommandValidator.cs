using Brasileirao.Application.Commands.ExcluirCampeonatoTime;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class ExcluirCampeonatoTimeCommandValidator : AbstractValidator<ExcluirCampeonatoTimeCommand>
{
    public ExcluirCampeonatoTimeCommandValidator()
    {
        RuleFor(ct => ct.Id)
            .NotEmpty().WithMessage("O ID nao pode ser vazio");
    }
}