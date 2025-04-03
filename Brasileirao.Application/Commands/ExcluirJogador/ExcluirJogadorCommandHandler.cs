using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.ExcluirJogador;

public class ExcluirJogadorCommandHandler : IRequestHandler<ExcluirJogadorCommand, Unit>
{
    private readonly IRepository<Jogador> _jogadorRespository;

    public ExcluirJogadorCommandHandler(IRepository<Jogador> jogadorRespository)
    {
        _jogadorRespository = jogadorRespository;
    }

    public async Task<Unit> Handle(ExcluirJogadorCommand request, CancellationToken cancellationToken)
    {
        var jogador = await _jogadorRespository.GetByIdAsync(request.Id);

        if (jogador is null)
            throw new KeyNotFoundException("Jogador nao encontrado");
        
        await _jogadorRespository.DeleteAsync(jogador.Id);
        return Unit.Value;
    }
}