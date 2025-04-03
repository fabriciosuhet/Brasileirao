using Brasileirao.Application.Commands.ExcluirJogador;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class ExcluirJogadorCommandValidator : AbstractValidator<ExcluirJogadorCommand>
{
    public ExcluirJogadorCommandValidator()
    {
        RuleFor(j => j.Id)
            .NotEmpty().WithMessage("O ID do jogador nao pode ser nulo");
    }
}