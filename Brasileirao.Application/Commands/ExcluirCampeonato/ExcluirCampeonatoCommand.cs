using MediatR;

namespace Brasileirao.Application.Commands.ExcluirCampeonato;

public class ExcluirCampeonatoCommand : IRequest<Unit>
{
    public Guid Id { get; private set; }

    public ExcluirCampeonatoCommand(Guid id)
    {
        Id = id;
    }
}