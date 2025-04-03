using Brasileirao.Application.Commands.AdicionarJogador;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class AdicionarJogadorCommandValidator : AbstractValidator<AdicionarJogadorCommand>
{
    public AdicionarJogadorCommandValidator()
    {
        RuleFor(j => j.Nome)
            .NotEmpty().WithMessage("O nome do jogador nao pode ser vazio")
            .MaximumLength(100).WithMessage("O nome do jogador nao pode ter mais de 100 caracteres");

        RuleFor(j => j.Posicao)
            .NotEmpty().WithMessage("A posicao do jogador nao pode ser vazia")
            .MaximumLength(100).WithMessage("A posicao do jogador nao pode ter mais de 100 caracteres");
        
        RuleFor(j => j.NumeroCamisa)
            .NotEmpty().WithMessage("O numero da camisa do jogador nao pode ser vazia")
            .MaximumLength(3).WithMessage("O numero da camisa nao pode ter mais de 3 caracteres");

        RuleFor(j => j.DataNascimento)
            .NotEmpty().WithMessage("A data de nascimento do jogador nao pode ser vazia");
    }
}