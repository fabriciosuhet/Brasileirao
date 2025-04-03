using Brasileirao.Domain.Entities;

namespace Brasileirao.Domain.Repositories;

public interface ITimeTituloRepository
{
    Task<IEnumerable<TimeTitulo>> GetAllAsync(string? query);
    Task<TimeTitulo?> GetByIdAsync(Guid timeId, Guid tituloId);
    Task CreateAsync(TimeTitulo timeTitulo);
    Task DeleteAsync(Guid timeId, Guid tituloId);
    
    
}