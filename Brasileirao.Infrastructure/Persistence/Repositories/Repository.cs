using Brasileirao.Domain.Repositories;

namespace Brasileirao.Infrastructure.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly BrasileiraoApiDbContext _context;

    public Repository(BrasileiraoApiDbContext context)
    {
        _context = context;
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task CreateAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var itemId = await _context.Set<T>().FindAsync(id);
        _context.Set<T>().Remove(itemId);
        await _context.SaveChangesAsync();
    }
}

