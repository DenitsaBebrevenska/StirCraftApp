using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Contracts;
public interface IRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(ISpecification<T>? spec, int id);
    Task<IList<T>> GetAllAsync(ISpecification<T>? spec);
    Task AddAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
    Task<bool> ExistsAsync(int id);
    Task<int> CountAsync(ISpecification<T>? spec);
}
