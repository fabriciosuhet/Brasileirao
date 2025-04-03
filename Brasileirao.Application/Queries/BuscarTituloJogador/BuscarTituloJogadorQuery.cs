using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTituloJogador;

public class BuscarTituloJogadorQuery : IRequest<TituloJogadorViewModel>
{
    public Guid Id { get; private set; }

    public BuscarTituloJogadorQuery(Guid id)
    {
        Id = id;
    }
}