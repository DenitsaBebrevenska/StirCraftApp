namespace StirCraftApp.Domain.Contracts;
public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec);
    Task<IList<T>> GetAllAsync();
    Task<IList<T>> GetAllWithSpecAsync(ISpecification<T> spec);
    Task<TResult?> GetEntityWithSpecAsync<TResult>(ISpecification<T, TResult> spec);
    Task<IList<TResult>> GetAllWithSpecAsync<TResult>(ISpecification<T, TResult> spec);
    Task AddAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
}
