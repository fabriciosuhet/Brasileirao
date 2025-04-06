using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AdicionarPartida;

public class AdicionarPartidaCommandHandler : IRequestHandler<AdicionarPartidaCommand, Guid>
{
    private readonly IRepository<Partida> _partidaRepository;

    public AdicionarPartidaCommandHandler(IRepository<Partida> partidaRepository)
    {
        _partidaRepository = partidaRepository;
    }

    public async Task<Guid> Handle(AdicionarPartidaCommand request, CancellationToken cancellationToken)
    {
        var partida = new Partida(request.DataDaPartida, request.CampeonatoId, request.TimeMandanteId,
            request.TimeVisitanteId);
        
        await _partidaRepository.CreateAsync(partida);
        return partida.Id;
    }
}