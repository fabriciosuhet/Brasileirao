using Brasileirao.Application.Commands.AdicionarTime;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class AdicionarTimeCommandValidator : AbstractValidator<AdicionarTimeCommand>
{
    public AdicionarTimeCommandValidator()
    {
        RuleFor(t => t.Nome)
            .NotEmpty().WithMessage("O nome nao pode ser vazio")
            .MaximumLength(100).WithMessage("O nome nao pode ter mais de 100 caracteres.");

        RuleFor(t => t.Estado)
            .NotEmpty().WithMessage("O estado nao pode ser vazio")
            .MaximumLength(100).WithMessage("O estado nao pode ter mais de 100 caracteres");
    }
}