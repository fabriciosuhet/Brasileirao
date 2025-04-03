using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTituloPorId;

public class BuscarTituloPorIdQueryHandler : IRequestHandler<BuscarTituloPorIdQuery, BuscarTituloDetalhesViewModel>
{
    private readonly ITituloRepository _tituloRepository;

    public BuscarTituloPorIdQueryHandler(ITituloRepository tituloRepository)
    {
        _tituloRepository = tituloRepository;
    }

    public async Task<BuscarTituloDetalhesViewModel> Handle(BuscarTituloPorIdQuery request, CancellationToken cancellationToken)
    {
        var titulo = await _tituloRepository.GetByIdAsync(request.Id);
        if (titulo is null) return null;

        var timesViewModel = titulo.Times
            .Select(tt => new TituloTimeViewModel(tt.TimeId, tt.TituloId, tt.Time.Nome, tt.Titulo.Nome, tt.Quantidade)).ToList();
        
        return new BuscarTituloDetalhesViewModel(titulo.Id, titulo.Nome, titulo.DataTituto, timesViewModel);
    }
}