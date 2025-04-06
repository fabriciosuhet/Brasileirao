using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarPartidaPorId;

public class BuscarPartidaPorIdQueryHandler : IRequestHandler<BuscarPartidaPorIdQuery, PartidaDetalhesViewModel>
{
    private readonly IPartidaRepository _partidaRepository;

    public BuscarPartidaPorIdQueryHandler(IPartidaRepository partidaRepository)
    {
        _partidaRepository = partidaRepository;
    }

    public async Task<PartidaDetalhesViewModel> Handle(BuscarPartidaPorIdQuery request, CancellationToken cancellationToken)
    {
        var partida = await _partidaRepository.BuscarPartidaPorIdAsync(request.Id);
        if (partida is null) return null;

        var eventosViewModel = partida.Eventos.Select(e =>
            new EventoPartidaViewModel(e.TipoEvento.ToString(), e.Jogador.Nome, e.Time.Nome, e.Minuto))
            .ToList();
        
        var partidaDetalhesViewModel = new PartidaDetalhesViewModel(partida.Id, partida.DataDaPartida,
            partida.Campeonato.Nome, partida.TimeMandante.Nome, partida.PlacarMandante, partida.TimeVisitante.Nome,
            partida.PlacarVisitante, eventosViewModel);

        return partidaDetalhesViewModel;
    }
}