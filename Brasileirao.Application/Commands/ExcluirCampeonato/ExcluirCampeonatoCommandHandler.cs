using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.ExcluirCampeonato;

public class ExcluirCampeonatoCommandHandler : IRequestHandler<ExcluirCampeonatoCommand, Unit>
{
    private readonly IRepository<Campeonato> _campeonatoRepository;

    public ExcluirCampeonatoCommandHandler(IRepository<Campeonato> campeonatoRepository)
    {
        _campeonatoRepository = campeonatoRepository;
    }

    public async Task<Unit> Handle(ExcluirCampeonatoCommand request, CancellationToken cancellationToken)
    {
        var campeonato = await _campeonatoRepository.GetByIdAsync(request.Id);
        if (campeonato is null)
            throw new KeyNotFoundException($"Time com ID: {request.Id} nao encontrado");

        await _campeonatoRepository.DeleteAsync(campeonato.Id);
        return Unit.Value;
    }
}