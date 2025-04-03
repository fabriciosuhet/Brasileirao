using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Brasileirao.Infrastructure.Persistence.Repositories;

public class CampeonatoTimeRepository : ICampeonatoTimeRepository
{
    private readonly BrasileiraoApiDbContext _context;

    public CampeonatoTimeRepository(BrasileiraoApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CampeonatoTime>> GetAllAsync(string? query)
    {
        return await _context.CampeonatosTime
            .AsNoTracking()
            .Where(ct => string.IsNullOrEmpty(query))
            .ToListAsync();
    }

    public async Task<CampeonatoTime?> GetByIdAsync(Guid id)
    {
        return await _context.CampeonatosTime
            .AsNoTracking()
            .Include(ct => ct.Time)
            .Include(ct => ct.Campeonato)
            .FirstOrDefaultAsync(ct => ct.Id.Equals(id));
    }
}