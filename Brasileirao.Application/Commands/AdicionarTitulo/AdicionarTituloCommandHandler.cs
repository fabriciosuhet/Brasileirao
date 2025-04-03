using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AdicionarTitulo;

public class AdicionarTituloCommandHandler : IRequestHandler<AdicionarTituloCommand, Guid>
{
    private readonly IRepository<Titulo> _tituloRepository;

    public AdicionarTituloCommandHandler(IRepository<Titulo> tituloRepository)
    {
        _tituloRepository = tituloRepository;
    }
    
    public async Task<Guid> Handle(AdicionarTituloCommand request, CancellationToken cancellationToken)
    {
        var titulo = new Titulo(request.Nome, request.DataTitulo);
        await _tituloRepository.CreateAsync(titulo);
        return titulo.Id;
    }
}