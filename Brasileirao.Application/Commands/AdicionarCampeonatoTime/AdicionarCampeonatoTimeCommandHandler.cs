using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AdicionarCampeonatoTime;

public class AdicionarCampeonatoTimeCommandHandler : IRequestHandler<AdicionarCampeonatoTimeCommand, Guid>
{
    private readonly IRepository<CampeonatoTime> _campeonatoTimeRepository;

    public AdicionarCampeonatoTimeCommandHandler(IRepository<CampeonatoTime> campeonatoTimeRepository)
    {
        _campeonatoTimeRepository = campeonatoTimeRepository;
    }

    public async Task<Guid> Handle(AdicionarCampeonatoTimeCommand request, CancellationToken cancellationToken)
    {
        var campeonatoTime = new CampeonatoTime(request.CampeonatoId, request.TimeId);
        await _campeonatoTimeRepository.CreateAsync(campeonatoTime);
        return campeonatoTime.Id;
    }
}