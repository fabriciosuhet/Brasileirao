using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodosOsTimes;

public class BuscarTodosOsTimesQueryHandler : IRequestHandler<BuscarTodosOsTimesQuery, IEnumerable<TimeViewModel>>
{
    private readonly ITimeRepository _timeRepository;

    public BuscarTodosOsTimesQueryHandler(ITimeRepository timeRepository)
    {
        _timeRepository = timeRepository;
    }

    public async Task<IEnumerable<TimeViewModel>> Handle(BuscarTodosOsTimesQuery request, CancellationToken cancellationToken)
    {
        var times = await _timeRepository.GetAllAsync(request.Query);
        
        var timesViewModel = times.Select(t => new TimeViewModel(t.Id, t.Nome));
        
        return timesViewModel;
    }
}