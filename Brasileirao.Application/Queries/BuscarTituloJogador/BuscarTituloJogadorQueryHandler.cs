using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTituloJogador;

public class BuscarTituloJogadorQueryHandler : IRequestHandler<BuscarTituloJogadorQuery, TituloJogadorViewModel>
{
    private readonly IJogadorTituloRepository _jogadorTituloRepository;

    public BuscarTituloJogadorQueryHandler(IJogadorTituloRepository jogadorTituloRepository)
    {
        _jogadorTituloRepository = jogadorTituloRepository;
    }
    
    public async Task<TituloJogadorViewModel> Handle(BuscarTituloJogadorQuery request, CancellationToken cancellationToken)
    {
        var tituloJogador = await _jogadorTituloRepository.GetByIdAsync(request.Id);
        if (tituloJogador is null) return null;

        return new TituloJogadorViewModel(tituloJogador.Jogador.Nome, tituloJogador.Titulo.Nome,
            tituloJogador.Quantidade);
    }
}