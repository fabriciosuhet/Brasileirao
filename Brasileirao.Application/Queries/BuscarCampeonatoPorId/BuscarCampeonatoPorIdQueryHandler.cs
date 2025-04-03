using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarCampeonatoPorId;

public class BuscarCampeonatoPorIdQueryHandler : IRequestHandler<BuscarCampeonatoPorIdQuery, CampeonatoDetalhesViewModel>
{
    private readonly ICampeonatoRepository _campeonatoRepository;

    public BuscarCampeonatoPorIdQueryHandler(ICampeonatoRepository campeonatoRepository)
    {
        _campeonatoRepository = campeonatoRepository;
    }

    public async Task<CampeonatoDetalhesViewModel> Handle(BuscarCampeonatoPorIdQuery request, CancellationToken cancellationToken)
    {
        var campeonato = await _campeonatoRepository.GetByIdAsync(request.Id);
        if (campeonato is null)
        {
            return null;
        }

        var campeonatoViewModel = new CampeonatoDetalhesViewModel(campeonato.Id, campeonato.Nome,
            campeonato.CampeonatoTimes.Select(ct => new TimeViewModel(ct.Id, ct.Time.Nome)));

        return campeonatoViewModel;
    }
}