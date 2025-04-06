using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTimePorId;

public class BuscarTimePorIdQueryHandler : IRequestHandler<BuscarTimePorIdQuery, TimesDetalhesViewModel>
{
    private readonly ITimeRepository _timeRepository;

    public BuscarTimePorIdQueryHandler(ITimeRepository timeRepository)
    {
        _timeRepository = timeRepository;
    }

    public async Task<TimesDetalhesViewModel> Handle(BuscarTimePorIdQuery request, CancellationToken cancellationToken)
    {
        var time = await _timeRepository.GetByIdAsync(request.Id);
        if (time is null)
            return null;

        var jogadorViewModel = time.Jogadores
            .Select(j => new JogadorViewModel(j.Id, j.Nome, j.Posicao))
            .ToList();

        var tituloTimeViewModel = time.Titulos
            .Select(t => new TituloTimeViewModel(t.TimeId, t.TituloId, t.Time.Nome, t.Titulo.Nome, t.Quantidade))
            .ToList();

        var campeonatoViewModel =
            time.CampeonatoTimes.Select(ct => new CampeonatoViewModel(ct.Id, ct.Campeonato.Nome, ct.Campeonato.Ano))
                .ToList();

        var partidaResumoMandanteViewModel = time.PartidasComoMandante
            .Select(p => new PartidaResumoViewModel(p.Id, p.DataDaPartida.Date, p.Campeonato.Nome, p.TimeMandante.Nome,
                p.PlacarMandante, p.TimeVisitante.Nome, p.PlacarVisitante))
            .ToList();

        var partidaResumoVisitanteViewModel = time.PartidasComoVisitante
            .Select(p => new PartidaResumoViewModel(p.Id,
            p.DataDaPartida.Date, p.Campeonato.Nome, p.TimeMandante.Nome,
            p.PlacarMandante, p.TimeVisitante.Nome, p.PlacarVisitante))
            .ToList();

        var registroDeGolsViewModel = time.GolsMarcados
            .Select(rg => new RegistroDeGolsViewModel(rg.Jogador.Nome, rg.Time.Nome, rg.GolMinuto))
            .ToList();

        var eventoPartidaViewModel = time.Eventos.Select(ep =>
            new EventoPartidaViewModel(ep.TipoEvento.ToString(), ep.Jogador.Nome, ep.Time.Nome, ep.Minuto))
            .ToList();
        
        var timeViewModel = new TimesDetalhesViewModel(
            time.Id,
            time.Nome,
            time.Estado,
            jogadorViewModel,
            tituloTimeViewModel,
            campeonatoViewModel,
            partidaResumoMandanteViewModel,
            partidaResumoVisitanteViewModel,
            registroDeGolsViewModel,
            eventoPartidaViewModel
        );
        
        return timeViewModel;
    }
}