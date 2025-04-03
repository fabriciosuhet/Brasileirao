using Brasileirao.Application.Commands.AdicionarTitulo;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class AdicionarTituloCommandValidator : AbstractValidator<AdicionarTituloCommand>
{
    public AdicionarTituloCommandValidator()
    {
        RuleFor(t => t.Nome)
            .NotEmpty().WithMessage("O nome do titulo nao pode ser vazio")
            .MaximumLength(100).WithMessage("O nome do titulo nao pode ter mais de 100 caracteres");

        RuleFor(t => t.DataTitulo)
            .NotEmpty().WithMessage("A data do titulo nao pode ser vazia");
    }
}