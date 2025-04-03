using Brasileirao.Application.Commands.AdicionarJogadorTitulo;
using FluentValidation;

namespace Brasileirao.Application.Validators;

public class AdicionarJogadorTituloCommandValidator : AbstractValidator<AdicionarJogadorTituloCommand>
{
    public AdicionarJogadorTituloCommandValidator()
    {
        RuleFor(jt => jt.JogadorId)
            .NotEmpty().WithMessage("O ID do jogador nao pode ser vazia");
        
        RuleFor(jt => jt.TituloId)
            .NotEmpty().WithMessage("O ID do Titulo nao pode ser vazia");

        RuleFor(jt => jt.Quantidade)
            .NotEmpty().WithMessage("A quantidade de titulo nao pode ser vazia");
    }
}