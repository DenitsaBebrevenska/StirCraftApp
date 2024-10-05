using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Contracts;
public interface IRepository<TEntity> where TEntity : BaseEntity
{
	Task<TEntity?> GetByIdAsync(int id);
	Task<IEnumerable<TEntity>> GetAllAsync();
	Task<IReadOnlyList<TEntity>> GetAllAsReadOnlyAsync();
	Task AddAsync(TEntity entity);
	void Delete(TEntity obj);
	void Update(TEntity entity);
	Task SaveAllChangesAsync();
}
