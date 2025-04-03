using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AdicionarJogadorTitulo;

public class AdicionarJogadorTituloCommandHandler : IRequestHandler<AdicionarJogadorTituloCommand, Guid>
{
    private readonly IRepository<JogadorTitulo> _jogadorTituloRepository;

    public AdicionarJogadorTituloCommandHandler(IRepository<JogadorTitulo> jogadorTituloRepository)
    {
        _jogadorTituloRepository = jogadorTituloRepository;
    }

    public async Task<Guid> Handle(AdicionarJogadorTituloCommand request, CancellationToken cancellationToken)
    {
        var jogadorTitulo = new JogadorTitulo(request.JogadorId, request.TituloId, request.Quantidade);
        await _jogadorTituloRepository.CreateAsync(jogadorTitulo);
        return jogadorTitulo.Id;
    }
}