using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Brasileirao.Infrastructure.Persistence.Repositories;

public class TituloRepository : ITituloRepository
{
    private readonly BrasileiraoApiDbContext _context;

    public TituloRepository(BrasileiraoApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Titulo>> GetAllAsync(string? query)
    {
        return await _context.Titulos
            .AsNoTracking()
            .Where(t => string.IsNullOrEmpty(query) || t.Nome.Equals(query))
            .ToListAsync();
    }

    public async Task<IEnumerable<Titulo>> GetByDateAsync(DateTime? date)
    {
        return await _context.Titulos
            .AsNoTracking()
            .Where(t => t.DataTituto.Date.Equals(date.Value.Date))
            .ToListAsync();
    }

    public async Task<Titulo?> GetByIdAsync(Guid id)
    {
        return await _context.Titulos
            .AsNoTracking()
            .Include(t => t.Jogadores)
            .Include(t => t.Times)
                .ThenInclude(tt => tt.Time)
            .FirstOrDefaultAsync(t => t.Id.Equals(id));
    }
}