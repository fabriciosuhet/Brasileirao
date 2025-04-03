using Brasileirao.Application.Commands.AtualizarJogadorTitulo;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class AtualizarJogadorTituloCommandValidator : AbstractValidator<AtualizarJogadorTituloCommand>
{
    public AtualizarJogadorTituloCommandValidator()
    {
        RuleFor(jt => jt.Id)
            .NotEmpty().WithMessage("O ID nao pode ser vazio");

        RuleFor(jt => jt.JogadorId)
            .NotEmpty().WithMessage("O ID do jogador nao pode ser vaziod");

        RuleFor(jt => jt.Quantidade)
            .NotEmpty().WithMessage("A quantidade nao pode ser vazia")
            .LessThan(0).WithMessage("A quantidade nao pode ser menor que zero");
    }
}