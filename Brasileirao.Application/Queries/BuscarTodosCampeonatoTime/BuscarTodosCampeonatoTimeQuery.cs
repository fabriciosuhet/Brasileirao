using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodosCampeonatoTime;

public class BuscarTodosCampeonatoTimeQuery : IRequest<IEnumerable<CampeonatoTimeViewModel>>
{
    public string? Query { get; set; }

    public BuscarTodosCampeonatoTimeQuery(string? query)
    {
        Query = query;
    }
}