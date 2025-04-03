using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodosTitulos;

public class BuscarTodosTitulosQueryHandler : IRequestHandler<BuscarTodosTitulosQuery, IEnumerable<TituloViewModel>>
{
    private readonly ITituloRepository _tituloRepository;

    public BuscarTodosTitulosQueryHandler(ITituloRepository tituloRepository)
    {
        _tituloRepository = tituloRepository;
    }

    public async Task<IEnumerable<TituloViewModel>> Handle(BuscarTodosTitulosQuery request, CancellationToken cancellationToken)
    {
        var titulos = await _tituloRepository.GetAllAsync(request.Query);

        var titulosViewModel = titulos
            .Select(t => new TituloViewModel(t.Id, t.Nome))
            .ToList();
        
        return titulosViewModel;
    }
}