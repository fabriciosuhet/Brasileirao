using Brasileirao.Domain.Entities;
using Brasileirao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Brasileirao.Infrastructure.Persistence.Repositories;

public class JogadorTituloRepository : IJogadorTituloRepository
{
    private readonly BrasileiraoApiDbContext _context;

    public JogadorTituloRepository(BrasileiraoApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<JogadorTitulo>> GetAllAsync(string? query)
    {
        return await _context.TitulosJogador
            .AsNoTracking()
            .Include(jt => jt.Jogador)
            .Include(jt => jt.Titulo)
            .Where(jt => string.IsNullOrEmpty(query) || jt.Quantidade.ToString().Contains(query))
            .ToListAsync();
    }

    public async Task<JogadorTitulo?> GetByIdAsync(Guid id)
    {
        return await _context.TitulosJogador
            .AsNoTracking()
            .Include(jt => jt.Jogador)
            .Include(jt => jt.Titulo)
            .FirstOrDefaultAsync(jt => jt.Id.Equals(id));
    }
}