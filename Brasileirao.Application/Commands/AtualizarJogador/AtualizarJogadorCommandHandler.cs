using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AtualizarJogador;

public class AtualizarJogadorCommandHandler : IRequestHandler<AtualizarJogadorCommand, Unit>
{
    private readonly IRepository<Jogador> _jogadorRepository;

    public AtualizarJogadorCommandHandler(IRepository<Jogador> jogadorRepository)
    {
        _jogadorRepository = jogadorRepository;
    }

    public async Task<Unit> Handle(AtualizarJogadorCommand request, CancellationToken cancellationToken)
    {
        var jogador = await _jogadorRepository.GetByIdAsync(request.Id);
        if (jogador is null)
            throw new KeyNotFoundException($"Jogador com ID: {request.Id} nao encontrado");
        
        jogador.AlterarDadosJogador(request.Posicao, request.NumeroCamisa);
        
        await _jogadorRepository.UpdateAsync(jogador);
        return Unit.Value;
    }
}