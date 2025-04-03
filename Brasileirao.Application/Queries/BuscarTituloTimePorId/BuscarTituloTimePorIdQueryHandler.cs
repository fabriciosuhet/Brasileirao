using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTituloTimePorId;

public class BuscarTituloTimePorIdQueryHandler : IRequestHandler<BuscarTituloTimePorIdQuery, TituloTimeViewModel>
{
    private readonly ITimeTituloRepository _timeTituloRepository;

    public BuscarTituloTimePorIdQueryHandler(ITimeTituloRepository timeTituloRepository)
    {
        _timeTituloRepository = timeTituloRepository;
    }

    public async Task<TituloTimeViewModel> Handle(BuscarTituloTimePorIdQuery request, CancellationToken cancellationToken)
    {
        var timeTitulo = await _timeTituloRepository.GetByIdAsync(request.TimeId, request.TituloId);
        if (timeTitulo is null) return null;

        return new TituloTimeViewModel(timeTitulo.TimeId, timeTitulo.TituloId, timeTitulo.Time.Nome, timeTitulo.Titulo.Nome,
            timeTitulo.Quantidade);
    }
}