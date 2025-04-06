using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AdicionarGol;

public class AdicionarGolCommandHandler : IRequestHandler<AdicionarGolCommand, Guid>
{
    private readonly IRepository<Partida> _partidaRepository;

    public AdicionarGolCommandHandler(IRepository<Partida> partidaRepository)
    {
        _partidaRepository = partidaRepository;
    }

    public async Task<Guid> Handle(AdicionarGolCommand request, CancellationToken cancellationToken)
    {
        var partida = await _partidaRepository.GetByIdAsync(request.PartidaId);
        if (partida is null) return Guid.Empty;
        
        partida.AdicionarGol(request.JogadorId, request.TimeId, request.GolMinuto);
        await _partidaRepository.UpdateAsync(partida);
        return partida.Id;
    }
}