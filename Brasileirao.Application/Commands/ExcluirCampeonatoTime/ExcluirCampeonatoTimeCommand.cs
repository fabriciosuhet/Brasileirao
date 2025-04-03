using MediatR;

namespace Brasileirao.Application.Commands.ExcluirCampeonatoTime;

public class ExcluirCampeonatoTimeCommand : IRequest<Unit>
{
    public Guid Id { get; private set; }

    public ExcluirCampeonatoTimeCommand(Guid id)
    {
        Id = id;
    }
}