using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.ExcluirTitulo;

public class ExcluirTituloCommandHandler : IRequestHandler<ExcluirTituloCommand, Unit>
{
    private readonly IRepository<Titulo> _tituloRepository;

    public ExcluirTituloCommandHandler(IRepository<Titulo> tituloRepository)
    {
        _tituloRepository = tituloRepository;
    }

    public async Task<Unit> Handle(ExcluirTituloCommand request, CancellationToken cancellationToken)
    {
        var titulo = await _tituloRepository.GetByIdAsync(request.Id);
        if (titulo is null)
            throw new KeyNotFoundException($"O titulo com o ID: {request.Id} nao foi encontrado");

        await _tituloRepository.DeleteAsync(titulo.Id);
        return Unit.Value;
    }
}