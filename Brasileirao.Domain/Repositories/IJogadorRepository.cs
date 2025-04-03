using Brasileirao.Domain.Entities;

namespace Brasileirao.Domain.Repositories;

public interface IJogadorRepository
{
    Task<ICollection<Jogador>> GetAllAsync(string? query);
    Task<Jogador?> GetByIdAsync(Guid jogadorId);
}