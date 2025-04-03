using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTimePorId;

public class BuscarTimePorIdQueryHandler : IRequestHandler<BuscarTimePorIdQuery, TimesDetalhesViewModel>
{
    private readonly ITimeRepository _timeRepository;

    public BuscarTimePorIdQueryHandler(ITimeRepository timeRepository)
    {
        _timeRepository = timeRepository;
    }

    public async Task<TimesDetalhesViewModel> Handle(BuscarTimePorIdQuery request, CancellationToken cancellationToken)
    {
        var time = await _timeRepository.GetByIdAsync(request.Id);
        if (time is null)
            return null;


        var timeViewModel = new TimesDetalhesViewModel(
            time.Id,
            time.Nome,
            time.Estado,
            time.Jogadores.Select(j => new JogadorViewModel(j.Id, j.Nome, j.Posicao)).ToList(),
            time.Titulos.Select(t => new TituloTimeViewModel(t.TimeId, t.TituloId, t.Time.Nome, t.Titulo.Nome, t.Quantidade)).ToList(),
            time.CampeonatoTimes.Select(ct => new CampeonatoViewModel(ct.Id, ct.Campeonato.Nome, ct.Campeonato.Ano))
                .ToList()
        );
        
        return timeViewModel;
    }
}