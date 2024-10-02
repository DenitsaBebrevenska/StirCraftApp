using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Infrastructure.Data;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
	public async Task<TEntity> GetAsync(int id)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<TEntity>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<TEntity>> GetAllAsReadOnlyAsync()
	{
		throw new NotImplementedException();
	}

	public async Task AddAsync(TEntity entity)
	{
		throw new NotImplementedException();
	}

	public async Task UpdateAsync(TEntity entity)
	{
		throw new NotImplementedException();
	}

	public async Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}
}
