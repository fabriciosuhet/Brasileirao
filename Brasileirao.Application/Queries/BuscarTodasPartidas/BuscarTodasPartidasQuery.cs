using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodasPartidas;

public class BuscarTodasPartidasQuery : IRequest<IEnumerable<PartidaViewModel>>
{
    public string? Query { get; private set; }

    public BuscarTodasPartidasQuery(string? query)
    {
        Query = query;
    }
}