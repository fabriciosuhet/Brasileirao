using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarCampeonatoTimePorId;

public class BuscarCampeonatoTimePorIdQueryHandler : IRequestHandler<BuscarCampeonatoTimePorIdQuery,  CampeonatoTimeDetalhesViewModel>
{
    private readonly ICampeonatoTimeRepository _campeonatoTimeRepository;

    public BuscarCampeonatoTimePorIdQueryHandler(ICampeonatoTimeRepository campeonatoTimeRepository)
    {
        _campeonatoTimeRepository = campeonatoTimeRepository;
    }

    public async Task<CampeonatoTimeDetalhesViewModel> Handle(BuscarCampeonatoTimePorIdQuery request, CancellationToken cancellationToken)
    {
        var  campeonatoTime = await _campeonatoTimeRepository.GetByIdAsync(request.Id);

        if (campeonatoTime is null)
        {
            return null;
        }

        var campeonatoTimeDetalhesViewModel = new CampeonatoTimeDetalhesViewModel(campeonatoTime.Id, campeonatoTime.CampeonatoId,
            campeonatoTime.Campeonato.Nome, campeonatoTime.TimeId, campeonatoTime.Time.Nome);
        
        return campeonatoTimeDetalhesViewModel;
    }
}