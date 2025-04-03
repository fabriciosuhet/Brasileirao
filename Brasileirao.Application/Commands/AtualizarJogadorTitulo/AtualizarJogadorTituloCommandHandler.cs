using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AtualizarJogadorTitulo;

public class AtualizarJogadorTituloCommandHandler : IRequestHandler<AtualizarJogadorTituloCommand, Unit>
{
    private readonly IRepository<JogadorTitulo> _jogadorTituloRepository;

    public AtualizarJogadorTituloCommandHandler(IRepository<JogadorTitulo> jogadorTituloRepository)
    {
        _jogadorTituloRepository = jogadorTituloRepository;
    }

    public async Task<Unit> Handle(AtualizarJogadorTituloCommand request, CancellationToken cancellationToken)
    {
        var jogadorTitulo = await _jogadorTituloRepository.GetByIdAsync(request.Id);
        if (jogadorTitulo is null)
            throw new KeyNotFoundException($"O titulo de jogador com ID: {request.Id} nao foi encontrado");
        
        jogadorTitulo.AtualizarTituloJogador(request.JogadorId, request.TituloId, request.Quantidade);

        await _jogadorTituloRepository.UpdateAsync(jogadorTitulo);
        return Unit.Value;
    }
}