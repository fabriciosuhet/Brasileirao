using Brasileirao.Application.Commands.ExcluirTime;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class ExcluirTimeCommandValidator : AbstractValidator<ExcluirTimeCommand>
{
    public ExcluirTimeCommandValidator()
    {
        RuleFor(t => t.Id)
            .NotEmpty().WithMessage("O ID do time nao pode ser nulo");
    }
}