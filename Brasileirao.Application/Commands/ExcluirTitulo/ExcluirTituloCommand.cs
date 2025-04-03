using MediatR;

namespace Brasileirao.Application.Commands.ExcluirTitulo;

public class ExcluirTituloCommand : IRequest<Unit>
{
    public Guid Id { get; private set; }

    public ExcluirTituloCommand(Guid id)
    {
        Id = id;
    }
}