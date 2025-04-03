using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodosTitulos;

public class BuscarTodosTitulosQuery : IRequest<IEnumerable<TituloViewModel>>
{
    public string? Query { get; private set; }

    public BuscarTodosTitulosQuery(string? query)
    {
        Query = query;
    }
}