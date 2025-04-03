using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using MediatR;

namespace Brasileirao.Application.Commands.AdicionarCampeonato;

public class AdicionarCampeonatoCommandHandler : IRequestHandler<AdicionarCampeonatoCommand, Guid>
{
    private readonly IRepository<Campeonato> _campeonatoRepository;

    public AdicionarCampeonatoCommandHandler(IRepository<Campeonato> campeonatoRepository)
    {
        _campeonatoRepository = campeonatoRepository;
    }

    public async Task<Guid> Handle(AdicionarCampeonatoCommand request, CancellationToken cancellationToken)
    {
        var campeonato = new Campeonato(request.Nome,  request.Ano);
        await _campeonatoRepository.CreateAsync(campeonato);
        return  campeonato.Id;
    }
}