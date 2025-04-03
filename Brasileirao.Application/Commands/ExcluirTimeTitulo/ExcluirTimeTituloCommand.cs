using MediatR;

namespace Brasileirao.Application.Commands.ExcluirTimeTitulo;

public class ExcluirTimeTituloCommand : IRequest<Unit>
{
    public Guid TimeId { get; set; }
    public Guid TituloId { get; set; }

    public ExcluirTimeTituloCommand(Guid timeId, Guid tituloId)
    {
        TimeId = timeId;
        TituloId = tituloId;
    }
}