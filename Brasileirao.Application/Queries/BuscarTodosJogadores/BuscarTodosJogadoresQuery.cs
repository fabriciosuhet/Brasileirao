using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodosJogadores;

public class BuscarTodosJogadoresQuery : IRequest<IEnumerable<JogadorViewModel>>
{
    public string? Query { get; private set; }

    public BuscarTodosJogadoresQuery(string? query)
    {
        Query = query;
    }
}