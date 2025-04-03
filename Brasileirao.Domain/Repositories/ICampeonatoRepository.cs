using Brasileirao.Domain.Entities;

namespace Brasileirao.Domain.Repositories;

public interface ICampeonatoRepository
{
    Task<IEnumerable<Campeonato>> GetAllAsync(string? query);
    Task<Campeonato?> GetByIdAsync(Guid id);
    
}