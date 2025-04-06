using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodasPartidas;

public class BuscarTodasPartidasQueryHandler : IRequestHandler<BuscarTodasPartidasQuery, IEnumerable<PartidaViewModel>>
{
    private readonly IPartidaRepository _partidaRepository;

    public BuscarTodasPartidasQueryHandler(IPartidaRepository partidaRepository)
    {
        _partidaRepository = partidaRepository;
    }

    public async Task<IEnumerable<PartidaViewModel>> Handle(BuscarTodasPartidasQuery request, CancellationToken cancellationToken)
    {
        var partidas = await _partidaRepository.BuscarTodasPartidasAsync(request.Query);

        var partidasViewModel = partidas.Select(p => new PartidaViewModel(p.DataDaPartida, p.Campeonato.Nome,
            p.TimeMandante.Nome, p.PlacarMandante, p.TimeVisitante.Nome, p.PlacarVisitante));

        return partidasViewModel;
    }
}