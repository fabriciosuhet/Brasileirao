using Brasileirao.Domain.Entities;

namespace Brasileirao.Domain.Repositories;

public interface ITituloRepository
{
    Task<IEnumerable<Titulo>> GetAllAsync(string? query);
    Task<IEnumerable<Titulo>> GetByDateAsync(DateTime? date);
    Task<Titulo?> GetByIdAsync(Guid id);
    
}