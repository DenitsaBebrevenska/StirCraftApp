using StirCraftApp.Domain.Contracts;

namespace StirCraftApp.Application.Contracts;

public interface IService<T> where T : class
{
    Task<T?> GetByIdAsync(int id);

    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> GetWithSpecAsync(ISpecification<T> spec, int id);

    Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec);

    Task<T> CreateAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}