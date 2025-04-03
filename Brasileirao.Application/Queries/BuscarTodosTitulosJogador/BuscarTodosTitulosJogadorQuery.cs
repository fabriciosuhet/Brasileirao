using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodosTitulosJogador;

public class BuscarTodosTitulosJogadorQuery : IRequest<IEnumerable<TituloJogadorViewModel>>
{
    public string? Query { get; private set; }

    public BuscarTodosTitulosJogadorQuery(string? query)
    {
        Query = query;
    }
}