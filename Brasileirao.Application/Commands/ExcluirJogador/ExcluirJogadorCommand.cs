using MediatR;

namespace Brasileirao.Application.Commands.ExcluirJogador;

public class ExcluirJogadorCommand : IRequest<Unit>
{
    public Guid Id { get; private set; }

    public ExcluirJogadorCommand(Guid id)
    {
        Id = id;
    }
}