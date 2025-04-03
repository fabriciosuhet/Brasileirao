using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Brasileirao.Infrastructure.Persistence.Repositories;

public class TimeRepository : ITimeRepository
{
    private readonly BrasileiraoApiDbContext _context;

    public TimeRepository(BrasileiraoApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Time>> GetAllAsync(string? query)
    {
        return await _context.Times.AsNoTracking()
            .Where(t => string.IsNullOrEmpty(query) || t.Nome.Contains(query) || t.Estado.Contains(query))
            .ToListAsync();
    }

    public async Task<Time?> GetByIdAsync(Guid timeId)
    {
        return await _context.Times.AsNoTracking()
            .Include(t => t.Jogadores)
            .Include(t => t.Titulos)
            .ThenInclude(tt => tt.Titulo)
            .Include(t => t.CampeonatoTimes)
            .ThenInclude(cc => cc.Campeonato)
            .FirstOrDefaultAsync(t => t.Id.Equals(timeId));
    }

    public async Task<bool> VerifyExistTimeAsync(string nome)
    {
        return await _context.Times.AsNoTracking().AnyAsync(t => t.Nome.Equals(nome));
    }
}