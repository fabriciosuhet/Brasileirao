using Brasileirao.Application.Commands.ExcluirTitulo;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class ExcluirTituloCommandValidator : AbstractValidator<ExcluirTituloCommand>
{
    public ExcluirTituloCommandValidator()
    {
        RuleFor(t => t.Id)
            .NotEmpty().WithMessage("O ID do titulo nao pode ser nulo");
    }
}