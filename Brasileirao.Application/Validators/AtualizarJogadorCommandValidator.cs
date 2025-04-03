using Brasileirao.Application.Commands.AtualizarCampeonato;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class AtualizarJogadorCommandValidator : AbstractValidator<AtualizarCampeonatoCommand>
{
    public AtualizarJogadorCommandValidator()
    {
        RuleFor(j => j.Nome)
            .NotEmpty().WithMessage("O nome do jogador nao pode ser vazio")
            .MaximumLength(100).WithMessage("O nome do jogador nao pode ter mais de 100 caracteres");

        RuleFor(j => j.Id)
            .NotEmpty().WithMessage("O id do jogador nao pode ser vazio");
    }
}