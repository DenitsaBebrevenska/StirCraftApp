using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using System.Collections.Concurrent;

namespace StirCraftApp.Infrastructure.Data;
public class UnitOfWork(StirCraftDbContext context) : IUnitOfWork
{
	private readonly ConcurrentDictionary<string, object> _repositories = new();
	public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
	{
		var type = typeof(TEntity).Name;

		return (Repository<TEntity>)_repositories.GetOrAdd(type, t =>
		{
			var repositoryType = typeof(Repository<>).MakeGenericType(typeof(TEntity));
			return Activator.CreateInstance(repositoryType, context)
				   ?? throw new InvalidOperationException($"Failed to create repository of type {t}");
		});
	}

	public async Task CompleteAsync()
	{
		await context.SaveChangesAsync();
	}
}
