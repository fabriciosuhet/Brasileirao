using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Brasileirao.Infrastructure.Persistence.Repositories;

public class CampeonatoRepository : ICampeonatoRepository
{
    private readonly BrasileiraoApiDbContext _context;

    public CampeonatoRepository(BrasileiraoApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Campeonato>> GetAllAsync(string? query)
    {
        return await _context.Campeonatos
            .AsNoTracking()
            .Where(c => string.IsNullOrEmpty(query) || c.Nome.Contains(query) || c.Ano.ToString().Contains(query))
            .ToListAsync();
    }

    public async Task<Campeonato?> GetByIdAsync(Guid id)
    {
        return await _context.Campeonatos
            .AsNoTracking()
            .Include(c => c.CampeonatoTimes)
                .ThenInclude(ct => ct.Time)
            .FirstOrDefaultAsync(c => c.Id.Equals(id));
    }
}