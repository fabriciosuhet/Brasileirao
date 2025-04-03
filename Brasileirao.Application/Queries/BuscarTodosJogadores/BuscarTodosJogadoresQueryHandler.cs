using Brasileirao.Application.Models.ViewModels;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Queries.BuscarTodosJogadores;

public class BuscarTodosJogadoresQueryHandler : IRequestHandler<BuscarTodosJogadoresQuery, IEnumerable<JogadorViewModel>>
{
    private readonly IJogadorRepository _jogadorRepository;

    public BuscarTodosJogadoresQueryHandler(IJogadorRepository jogadorRepository)
    {
        _jogadorRepository = jogadorRepository;
    }

    public async Task<IEnumerable<JogadorViewModel>> Handle(BuscarTodosJogadoresQuery request, CancellationToken cancellationToken)
    {
        var jogadores = await _jogadorRepository.GetAllAsync(request.Query);
        
        var jogadoresViewModel = jogadores
            .Select(j => new JogadorViewModel(j.Id, j.Nome, j.Posicao)).ToList();
        
        return jogadoresViewModel;
    }
}