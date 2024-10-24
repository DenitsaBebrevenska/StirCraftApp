using StirCraftApp.Domain.Contracts;
using System.Collections.Concurrent;

namespace StirCraftApp.Infrastructure.Data;
public class UnitOfWork(StirCraftDbContext context) : IUnitOfWork
{
    private readonly ConcurrentDictionary<string, object> _repositories = new();
    public IRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T).Name;

        return (IRepository<T>)_repositories.GetOrAdd(type, t =>
        {
            var repositoryType = typeof(Repository<>).MakeGenericType(typeof(T));
            return Activator.CreateInstance(repositoryType, context)
                   ?? throw new InvalidOperationException($"Failed to create repository of type {t}");
        });
    }

    public async Task<bool> CompleteAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }
}
