using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Brasileirao.Infrastructure.Persistence.Repositories;

public class TimeTituloRepository : ITimeTituloRepository
{
    private readonly BrasileiraoApiDbContext _context;

    public TimeTituloRepository(BrasileiraoApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TimeTitulo>> GetAllAsync(string? query)
    {
        return await _context.TitulosTime
            .AsNoTracking()
            .Include(tt => tt.Time)
            .Include(tt => tt.Titulo)
            .Where(tt => string.IsNullOrEmpty(query) || tt.Quantidade.ToString().Contains(query))
            .ToListAsync();
    }

    public async Task<TimeTitulo?> GetByIdAsync(Guid timeId, Guid tituloId)
    {
        return await _context.TitulosTime
            .Include(tt => tt.Time)
            .Include(tt => tt.Titulo)
            .SingleOrDefaultAsync(tt => tt.TimeId.Equals(timeId) && tt.TituloId.Equals(tituloId));
    }

    public async Task CreateAsync(TimeTitulo timeTitulo)
    {
        await _context.TitulosTime.AddAsync(timeTitulo);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteAsync(Guid timeId, Guid tituloId)
    {
        var entity =
            await _context.TitulosTime.SingleOrDefaultAsync(tt =>
                tt.TimeId.Equals(timeId) && tt.TituloId.Equals(tituloId));
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}