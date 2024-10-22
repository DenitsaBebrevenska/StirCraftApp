using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Contracts;
public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity?> GetEntityWithSpecAsync(ISpecification<TEntity> spec);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IReadOnlyList<TEntity>> GetAllAsReadOnlyAsync();
    Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity> spec);
    Task<TResult?> GetEntityWithSpecAsync<TResult>(ISpecification<TEntity, TResult> spec);
    Task<IEnumerable<TResult>> GetAllWithSpecAsync<TResult>(ISpecification<TEntity, TResult> spec);
    Task AddAsync(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
}
