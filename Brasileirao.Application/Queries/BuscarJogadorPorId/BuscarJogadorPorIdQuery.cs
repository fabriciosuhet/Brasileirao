using Brasileirao.Application.Models.ViewModels;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarJogadorPorId;

public class BuscarJogadorPorIdQuery : IRequest<JogadorDetalhesViewModel>
{
    public Guid Id { get; private set; }

    public BuscarJogadorPorIdQuery(Guid id)
    {
        Id = id;
    }
}