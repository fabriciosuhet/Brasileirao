using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AtualizarTimeTitulo;

public class AtualizarTimeTituloCommandHandler : IRequestHandler<AtualizarTimeTituloCommand, Unit>
{
    private readonly IRepository<TimeTitulo> _timeTituloRepository;

    public AtualizarTimeTituloCommandHandler(IRepository<TimeTitulo> timeTituloRepository)
    {
        _timeTituloRepository = timeTituloRepository;
    }

    public async Task<Unit> Handle(AtualizarTimeTituloCommand request, CancellationToken cancellationToken)
    {
        var timeTitulo = await _timeTituloRepository.GetByIdAsync(request.Id);
        if (timeTitulo is null)
        {
            throw new KeyNotFoundException("O ID do titulo time nao foi encontrado");
        }
        
        timeTitulo.AtualizarQuantidade(request.Quantidade);
        await _timeTituloRepository.UpdateAsync(timeTitulo);
        return Unit.Value;
    }
}