using Brasileirao.Application.Commands.ExcluirJogadorTitulo;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class ExcluirJogadorTituloCommandValidator : AbstractValidator<ExcluirJogadorTituloCommand>
{
    public ExcluirJogadorTituloCommandValidator()
    {
        RuleFor(jt => jt.Id)
            .NotEmpty().WithMessage("O ID nao pode ser vazio");
    }
}