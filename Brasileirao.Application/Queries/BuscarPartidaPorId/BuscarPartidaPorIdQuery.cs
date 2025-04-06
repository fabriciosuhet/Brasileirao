using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarPartidaPorId;

public class BuscarPartidaPorIdQuery : IRequest<PartidaDetalhesViewModel>
{
    public Guid Id { get; private set; }

    public BuscarPartidaPorIdQuery(Guid id)
    {
        Id = id;
    }
}