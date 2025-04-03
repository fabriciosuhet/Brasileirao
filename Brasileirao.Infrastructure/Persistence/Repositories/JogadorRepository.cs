using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Brasileirao.Infrastructure.Persistence.Repositories;

public class JogadorRepository : IJogadorRepository
{
    private readonly BrasileiraoApiDbContext _context;

    public JogadorRepository(BrasileiraoApiDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Jogador>> GetAllAsync(string? query)
    {
        return await _context.Jogadores.AsNoTracking().Where(j =>
            string.IsNullOrEmpty(query) || j.Nome.Contains(query) || j.NumeroCamisa.Contains(query)).ToListAsync();
    }

    public async Task<Jogador?> GetByIdAsync(Guid jogadorId)
    {
        return await _context.Jogadores
            .Include(j => j.Time)
            .Include(j => j.Titulos)
                .ThenInclude(jt => jt.Titulo)
            .FirstOrDefaultAsync(j => j.Id.Equals(jogadorId));
    }
}