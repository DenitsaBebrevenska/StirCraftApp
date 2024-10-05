using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Infrastructure.Data;
public class Repository<TEntity>(StirCraftDbContext context) : IRepository<TEntity>
	where TEntity : BaseEntity
{
	private DbSet<TEntity> GetDbSet()
		=> context.Set<TEntity>();

	public async Task<TEntity?> GetByIdAsync(int id)
		=> await GetDbSet()
			.FindAsync(id);

	public async Task<IEnumerable<TEntity>> GetAllAsync()
		=> await GetDbSet()
			.ToListAsync();

	public async Task<IEnumerable<TEntity>> GetAllAsReadOnlyAsync()
		=> await GetDbSet()
			.AsNoTracking()
			.ToListAsync();

	public async Task AddAsync(TEntity entity)
		=> await context.AddAsync(entity);

	public void Delete(TEntity obj)
		=> context.Remove(obj);

	public async Task SaveAllChangesAsync()
		=> await context.SaveChangesAsync();
}
