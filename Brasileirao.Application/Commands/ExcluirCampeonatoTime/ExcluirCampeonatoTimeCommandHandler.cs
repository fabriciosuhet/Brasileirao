using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.ExcluirCampeonatoTime;

public class ExcluirCampeonatoTimeCommandHandler : IRequestHandler<ExcluirCampeonatoTimeCommand, Unit>
{
    private readonly IRepository<CampeonatoTime> _campeonatoTimeRepository;

    public ExcluirCampeonatoTimeCommandHandler(IRepository<CampeonatoTime> campeonatoTimeRepository)
    {
        _campeonatoTimeRepository = campeonatoTimeRepository;
    }

    public async Task<Unit> Handle(ExcluirCampeonatoTimeCommand request, CancellationToken cancellationToken)
    {
        var campeonatoTime = await _campeonatoTimeRepository.GetByIdAsync(request.Id);
        if (campeonatoTime is null)
            throw new KeyNotFoundException($"O campeonato do time com ID: {request.Id} nao foi encontrado");
        
        await _campeonatoTimeRepository.DeleteAsync(campeonatoTime.Id);
        return Unit.Value;
    }
}