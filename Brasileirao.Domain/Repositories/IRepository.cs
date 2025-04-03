namespace Brasileirao.Domain.Repositories;

public interface IRepository<T> where T : class 
{
    Task<T?> GetByIdAsync(Guid id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}