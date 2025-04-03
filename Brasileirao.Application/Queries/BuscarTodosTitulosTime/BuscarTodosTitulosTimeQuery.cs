using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodosTitulosTime;

public class BuscarTodosTitulosTimeQuery : IRequest<IEnumerable<TituloTimeViewModel>>
{
    public string? Query { get; private set; }

    public BuscarTodosTitulosTimeQuery(string? query)
    {
        Query = query;
    }
}