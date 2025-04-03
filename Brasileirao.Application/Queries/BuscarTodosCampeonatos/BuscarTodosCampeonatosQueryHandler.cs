using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodosCampeonatos;

public class BuscarTodosCampeonatosQueryHandler : IRequestHandler<BuscarTodosCampeonatosQuery, IEnumerable<CampeonatoViewModel>>
{
    private readonly ICampeonatoRepository _campeonatoRepository;

    public BuscarTodosCampeonatosQueryHandler(ICampeonatoRepository campeonatoRepository)
    {
        _campeonatoRepository = campeonatoRepository;
    }

    public async Task<IEnumerable<CampeonatoViewModel>> Handle(BuscarTodosCampeonatosQuery request, CancellationToken cancellationToken)
    {
        var campeonatos = await _campeonatoRepository.GetAllAsync(request.Query);

        var campeoantoViewModel = 
            campeonatos.Select(c => new CampeonatoViewModel(c.Id, c.Nome, c.Ano));
        
        return campeoantoViewModel;
    }
}