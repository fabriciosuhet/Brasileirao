using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AtualizarCampeonato;

public class AtualizarCampeonatoCommandHandler : IRequestHandler<AtualizarCampeonatoCommand, Unit>
{
    private readonly IRepository<Campeonato> _campeonatoRepository;

    public AtualizarCampeonatoCommandHandler(IRepository<Campeonato> campeonatoRepository)
    {
        _campeonatoRepository = campeonatoRepository;
    }

    public async Task<Unit> Handle(AtualizarCampeonatoCommand request, CancellationToken cancellationToken)
    {
        var campeonato = await _campeonatoRepository.GetByIdAsync(request.Id);
        if (campeonato is null)
        {
            throw new KeyNotFoundException($"Campeonato com o ID: {request.Id} nao encontrado");
        }
        campeonato.AlterarNomeCampeonato(request.Nome);
        
        await _campeonatoRepository.UpdateAsync(campeonato);
        return Unit.Value;
    }
}