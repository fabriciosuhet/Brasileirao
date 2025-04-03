using Brasileirao.Domain.Entities;

namespace Brasileirao.Domain.Repositories;

public interface ICampeonatoTimeRepository 
{
   Task<IEnumerable<CampeonatoTime>> GetAllAsync(string? query);
   Task<CampeonatoTime?> GetByIdAsync(Guid id);
}