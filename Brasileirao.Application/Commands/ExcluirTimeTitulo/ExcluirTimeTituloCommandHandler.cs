using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.ExcluirTimeTitulo;

public class ExcluirTimeTituloCommandHandler : IRequestHandler<ExcluirTimeTituloCommand, Unit>
{
    private readonly ITimeTituloRepository _timeTituloRepository;

    public ExcluirTimeTituloCommandHandler(ITimeTituloRepository timeTituloRepository)
    {
        _timeTituloRepository = timeTituloRepository;
    }

    public async Task<Unit> Handle(ExcluirTimeTituloCommand request, CancellationToken cancellationToken)
    {
        var timeTitulo = await _timeTituloRepository.GetByIdAsync(request.TimeId, request.TituloId);
        if (timeTitulo is null)
        {
            throw new KeyNotFoundException("O ID do titulo time nao foi encontrado");
        }
        await _timeTituloRepository.DeleteAsync(timeTitulo.TimeId, timeTitulo.TituloId);
        return Unit.Value;
    }
}