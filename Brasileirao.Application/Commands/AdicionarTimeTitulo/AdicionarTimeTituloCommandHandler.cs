using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AdicionarTimeTitulo;

public class AdicionarTimeTituloCommandHandler : IRequestHandler<AdicionarTimeTiuloCommand, (Guid, Guid)>
{
    private readonly ITimeTituloRepository _timeTituloRepository;

    public AdicionarTimeTituloCommandHandler(ITimeTituloRepository timeTituloRepository)
    {
        _timeTituloRepository = timeTituloRepository;
    }

    public async Task<(Guid, Guid)> Handle(AdicionarTimeTiuloCommand request, CancellationToken cancellationToken)
    {
        var timeTitulo = new TimeTitulo(request.TimeId, request.TituloId, request.Quantidade);
        await _timeTituloRepository.CreateAsync(timeTitulo);
        return (timeTitulo.TimeId, timeTitulo.TituloId);
    }
}