using Brasileirao.Domain.Entities;

namespace Brasileirao.Domain.Repositories;

public interface IPartidaRepository
{
    Task<IEnumerable<Partida>> BuscarTodasPartidasAsync(string? query);
    Task<Partida?> BuscarPartidaPorIdAsync(Guid id);
}