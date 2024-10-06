using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Contracts;
public interface IRepository<TEntity> where TEntity : BaseEntity
{
	Task<TEntity?> GetByIdAsync(int id);
	Task<TEntity?> GetEntityWithSpecAsync(ISpecification<TEntity> spec);
	Task<IEnumerable<TEntity>> GetAllAsync();
	Task<IReadOnlyList<TEntity>> GetAllAsReadOnlyAsync();
	Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity> spec);
	Task AddAsync(TEntity entity);
	void Delete(TEntity obj);
	void Update(TEntity entity);
	Task SaveAllChangesAsync();
}
