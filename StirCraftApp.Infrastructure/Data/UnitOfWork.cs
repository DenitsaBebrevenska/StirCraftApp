using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using System.Collections.Concurrent;

namespace StirCraftApp.Infrastructure.Data;
public class UnitOfWork(StirCraftDbContext context) : IUnitOfWork
{
    //todo remove soft delete interceptor and leave unit of work to handle deletion
    private readonly ConcurrentDictionary<string, object> _repositories = new();
    public IRepository<T> Repository<T>() where T : BaseEntity
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
        foreach (var entry in context.ChangeTracker.Entries<ISoftDeletable>())
        {
            if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.Entity.IsDeleted = true;
            }
        }

        return await context.SaveChangesAsync() > 0;
    }
}
