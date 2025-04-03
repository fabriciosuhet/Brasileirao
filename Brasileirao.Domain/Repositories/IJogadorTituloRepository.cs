using Brasileirao.Domain.Entities;

namespace Brasileirao.Domain.Repositories;

public interface IJogadorTituloRepository
{
    Task<IEnumerable<JogadorTitulo>>  GetAllAsync(string? query);
    Task<JogadorTitulo?> GetByIdAsync(Guid id);
}