using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodosOsTimes;

public class BuscarTodosOsTimesQuery : IRequest<IEnumerable<TimeViewModel>>
{
    public string? Query { get; private set; }

    public BuscarTodosOsTimesQuery(string? query)
    {
        Query = query;
    }
}