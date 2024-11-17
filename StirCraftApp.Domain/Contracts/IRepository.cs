using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Contracts;
public interface IRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec, int id);
    Task<IList<T>> GetAllAsync();
    Task<IList<T>> GetAllWithSpecAsync(ISpecification<T> spec);
    //Task<TResult?> GetEntityWithSpecAsync<TResult>(ISpecification<T, TResult> spec);
    //Task<IList<TResult>> GetAllWithSpecAsync<TResult>(ISpecification<T, TResult> spec);
    Task AddAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
    Task<bool> ExistsAsync(int id);
}
