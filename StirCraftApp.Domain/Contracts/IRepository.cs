namespace StirCraftApp.Domain.Contracts;
public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllAsReadOnlyAsync();
    Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec);
    Task<TResult?> GetEntityWithSpecAsync<TResult>(ISpecification<T, TResult> spec);
    Task<IEnumerable<TResult>> GetAllWithSpecAsync<TResult>(ISpecification<T, TResult> spec);
    Task AddAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
}
