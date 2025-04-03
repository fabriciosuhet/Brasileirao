using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.ExcluirJogadorTitulo;

public class ExcluirJogadorTituloCommandHandler : IRequestHandler<ExcluirJogadorTituloCommand, Unit>
{
    private readonly IRepository<JogadorTitulo> _jogadorTituloRepository;

    public ExcluirJogadorTituloCommandHandler(IRepository<JogadorTitulo> jogadorTituloRepository)
    {
        _jogadorTituloRepository = jogadorTituloRepository;
    }

    public async Task<Unit> Handle(ExcluirJogadorTituloCommand request, CancellationToken cancellationToken)
    {
        var jogadorTitulo = await _jogadorTituloRepository.GetByIdAsync(request.Id);
        if (jogadorTitulo is null)
            throw new KeyNotFoundException($"O titulo de jogador com ID: {request.Id} nao foi encontrado");

        await _jogadorTituloRepository.DeleteAsync(jogadorTitulo.Id);
        return  Unit.Value;
    }
}