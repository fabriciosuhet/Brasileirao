using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodosTitulosJogador;

public class BuscarTodosTitulosJogadorQueryHandler : IRequestHandler<BuscarTodosTitulosJogadorQuery, IEnumerable<TituloJogadorViewModel>>
{
    private readonly IJogadorTituloRepository _jogadorTituloRepository;

    public BuscarTodosTitulosJogadorQueryHandler(IJogadorTituloRepository jogadorTituloRepository)
    {
        _jogadorTituloRepository = jogadorTituloRepository;
    }

    public async Task<IEnumerable<TituloJogadorViewModel>> Handle(BuscarTodosTitulosJogadorQuery request, CancellationToken cancellationToken)
    {
        var titulosJogador = await _jogadorTituloRepository.GetAllAsync(request.Query);

        var tituloJogadorViewModel =
            titulosJogador.Select(tj => new TituloJogadorViewModel(tj.Jogador.Nome, tj.Titulo.Nome, tj.Quantidade))
                .ToList();
        
        return tituloJogadorViewModel;
    }
}