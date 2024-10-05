using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Contracts;
public interface IRepository<TEntity> where TEntity : BaseEntity
{
	Task<TEntity?> GetByIdAsync(int id);
	Task<IEnumerable<TEntity>> GetAllAsync();
	Task<IEnumerable<TEntity>> GetAllAsReadOnlyAsync();
	Task AddAsync(TEntity entity);
	void Delete(TEntity obj);

	Task SaveAllChangesAsync();
}
