using MediatR;

namespace Brasileirao.Application.Commands.ExcluirJogadorTitulo;

public class ExcluirJogadorTituloCommand : IRequest<Unit>
{
    public ExcluirJogadorTituloCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}