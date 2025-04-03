using MediatR;

namespace Brasileirao.Application.Commands.ExcluirTime;

public class ExcluirTimeCommand : IRequest<Unit>
{
    public Guid Id { get; private set; }

    public ExcluirTimeCommand(Guid id)
    {
        Id = id;
    }
}