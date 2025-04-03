using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodosTitulosTime;

public class BuscarTodosTitulosTimeQueryHandler : IRequestHandler<BuscarTodosTitulosTimeQuery, IEnumerable<TituloTimeViewModel>>
{
    private readonly ITimeTituloRepository _timeTituloRepository;

    public BuscarTodosTitulosTimeQueryHandler(ITimeTituloRepository timeTituloRepository)
    {
        _timeTituloRepository = timeTituloRepository;
    }

    public async Task<IEnumerable<TituloTimeViewModel>> Handle(BuscarTodosTitulosTimeQuery request, CancellationToken cancellationToken)
    {
        var timeTitulo = await _timeTituloRepository.GetAllAsync(request.Query);

        var tituloTimeViewModel =
            timeTitulo.Select(tt => new TituloTimeViewModel(tt.TimeId, tt.TituloId ,tt.Time.Nome, tt.Titulo.Nome, tt.Quantidade));

        return tituloTimeViewModel;
    }
}