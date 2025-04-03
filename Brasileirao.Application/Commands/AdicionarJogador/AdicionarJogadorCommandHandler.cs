using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AdicionarJogador;

public class AdicionarJogadorCommandHandler : IRequestHandler<AdicionarJogadorCommand, Guid>
{
    private readonly IRepository<Jogador> _jogadorRepository;

    public AdicionarJogadorCommandHandler(IRepository<Jogador> jogadorRepository)
    {
        _jogadorRepository = jogadorRepository;
    }

    public async Task<Guid> Handle(AdicionarJogadorCommand request, CancellationToken cancellationToken)
    {
        var jogador = new Jogador(request.Nome, request.Posicao, request.DataNascimento, request.NumeroCamisa,
            request.TimeId);

        await _jogadorRepository.CreateAsync(jogador);
        return jogador.Id;
    }
}