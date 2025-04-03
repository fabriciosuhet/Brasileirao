using Brasileirao.Application.Commands.AtualizarTime;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class AtualizarTimeCommandValidator : AbstractValidator<AtualizarTimeCommand>
{
    public AtualizarTimeCommandValidator()
    {
        RuleFor(t => t.Nome)
            .NotEmpty().WithMessage("O nome do time nao pode ser vazio")
            .MaximumLength(100).WithMessage("O nome nao pode ter mais de 100 caracteres");
        
        RuleFor(t => t.Id)
            .NotEmpty().WithMessage("O id do time nao pode ser vazio");
    }
}