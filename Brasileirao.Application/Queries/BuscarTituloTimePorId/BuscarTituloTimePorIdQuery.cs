using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTituloTimePorId;

public class BuscarTituloTimePorIdQuery : IRequest<TituloTimeViewModel>
{
    public Guid TimeId { get; private set; }
    public Guid TituloId { get; private set; }

    public BuscarTituloTimePorIdQuery(Guid timeId, Guid tituloId)
    {
        TimeId = timeId;
        TituloId = tituloId;
    }
}