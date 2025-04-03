using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodosCampeonatos;

public class BuscarTodosCampeonatosQuery : IRequest<IEnumerable<CampeonatoViewModel>>
{
    public string? Query { get; private set; }

    public BuscarTodosCampeonatosQuery(string? query)
    {
        Query = query;
    }
}