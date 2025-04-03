using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarJogadorPorId;

public class BuscarJogadorPorIdQueryHandler : IRequestHandler<BuscarJogadorPorIdQuery, JogadorDetalhesViewModel>
{
    private readonly IJogadorRepository _jogadorRepository;

    public BuscarJogadorPorIdQueryHandler(IJogadorRepository jogadorRepository)
    {
        _jogadorRepository = jogadorRepository;
    }

    public async Task<JogadorDetalhesViewModel> Handle(BuscarJogadorPorIdQuery request, CancellationToken cancellationToken)
    {
        var jogador = await _jogadorRepository.GetByIdAsync(request.Id);
        if (jogador is null) return null;

        var titulosViewModel = jogador.Titulos
            .Select(jt => new TituloViewModel(jt.Titulo.Id, jt.Titulo.Nome))
            .ToList();

        var jogadorDetalhesViewModel = new JogadorDetalhesViewModel(jogador.Id, jogador.Nome, jogador.Posicao,
            jogador.NumeroCamisa, jogador.Time.Nome, titulosViewModel);

        return jogadorDetalhesViewModel;

    }
}