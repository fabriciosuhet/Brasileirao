using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AtualizarCampeonatoTime;

public class AtualizarCampeonatoTimeCommandHandler : IRequestHandler<AtualizarCampeonatoTimeCommand, Unit>
{
    private readonly IRepository<CampeonatoTime> _campeonatoTimeRepository;

    public AtualizarCampeonatoTimeCommandHandler(IRepository<CampeonatoTime> campeonatoTimeRepository)
    {
        _campeonatoTimeRepository = campeonatoTimeRepository;
    }

    public async Task<Unit> Handle(AtualizarCampeonatoTimeCommand request, CancellationToken cancellationToken)
    {
        var campeonatoTime = await _campeonatoTimeRepository.GetByIdAsync(request.Id);
        if (campeonatoTime is null)
            throw new KeyNotFoundException($"O campeonato do time com ID: {request.Id} nao foi encontrado");
        
        campeonatoTime.AtualizarCampeonatoTime(request.CampeonatoId, request.TimeId);
        await _campeonatoTimeRepository.UpdateAsync(campeonatoTime);
        return Unit.Value;
    }
}