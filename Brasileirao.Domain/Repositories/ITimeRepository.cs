using Brasileirao.Domain.Entities;

namespace Brasileirao.Domain.Repositories;

public interface ITimeRepository
{
    Task<IEnumerable<Time>> GetAllAsync(string? query);
    Task<Time?> GetByIdAsync(Guid timeId);
    Task<bool> VerifyExistTimeAsync(string nome);
}