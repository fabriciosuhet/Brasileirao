using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AdicionarEvento;

public class AdicionarEventoCommandHandler : IRequestHandler<AdicionarEventoCommand, Guid>
{
    private readonly IRepository<Partida> _partidaRepository;

    public AdicionarEventoCommandHandler(IRepository<Partida> partidaRepository)
    {
        _partidaRepository = partidaRepository;
    }

    public async Task<Guid> Handle(AdicionarEventoCommand request, CancellationToken cancellationToken)
    {
        var partida = await _partidaRepository.GetByIdAsync(request.PartidaId);
        if (partida is null) return Guid.Empty;
        
        partida.AdicionarEvento(request.JogadorId, request.TimeId, request.Minuto, request.TipoEvento);
        await _partidaRepository.CreateAsync(partida);
        return partida.Id;
    }
}