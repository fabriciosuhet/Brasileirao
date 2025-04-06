using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Brasileirao.Infrastructure.Persistence.Repositories;

public class PartidaRepository : IPartidaRepository
{
    private readonly BrasileiraoApiDbContext _context;

    public PartidaRepository(BrasileiraoApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Partida>> BuscarTodasPartidasAsync(string? query)
    {
        DateTime? dataQuery = null;
        if (DateTime.TryParse(query, out DateTime parsedData))
        {
            dataQuery = parsedData.Date;
        }
        
        return await _context.Partidas.AsNoTracking()
            .Include(p => p.TimeMandante)
            .Include(p => p.TimeVisitante)
            .Include(p => p.Campeonato)
            .Where(p =>
            string.IsNullOrEmpty(query) || (dataQuery.HasValue &&  p.DataDaPartida.Date.Equals(dataQuery.Value)) || p.Campeonato.Nome.Equals(query) ||
            p.TimeMandante.Nome.Equals(query) || p.TimeVisitante.Nome.Equals(query)).ToListAsync();
    }

    public async Task<Partida?> BuscarPartidaPorIdAsync(Guid id)
    {
        return await _context.Partidas.AsNoTracking()
            .Include(p => p.TimeMandante)
            .Include(p => p.TimeVisitante)
            .Include(p => p.Campeonato)
            .Include(p => p.Gols)
            .Include(p => p.Eventos)
            .FirstOrDefaultAsync(p => p.Id.Equals(id));
    }
}