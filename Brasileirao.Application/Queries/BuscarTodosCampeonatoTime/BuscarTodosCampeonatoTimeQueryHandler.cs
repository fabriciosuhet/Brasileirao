using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodosCampeonatoTime;

public class BuscarTodosCampeonatoTimeQueryHandler : IRequestHandler<BuscarTodosCampeonatoTimeQuery, IEnumerable<CampeonatoTimeViewModel>>
{
    private readonly ICampeonatoTimeRepository _campeonatoTimeRepository;

    public BuscarTodosCampeonatoTimeQueryHandler(ICampeonatoTimeRepository campeonatoTimeRepository)
    {
        _campeonatoTimeRepository = campeonatoTimeRepository;
    }

    public async Task<IEnumerable<CampeonatoTimeViewModel>> Handle(BuscarTodosCampeonatoTimeQuery request, CancellationToken cancellationToken)
    {
        var campeonatosTimes = await _campeonatoTimeRepository.GetAllAsync(request.Query);

        var campeonatoTimeViewModel =
            campeonatosTimes.Select(ct => new CampeonatoTimeViewModel(ct.Id, ct.CampeonatoId, ct.TimeId))
                .ToList();
        
        return campeonatoTimeViewModel;
    }
}