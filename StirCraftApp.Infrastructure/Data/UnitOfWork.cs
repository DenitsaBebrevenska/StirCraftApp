using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using System.Collections.Concurrent;

namespace StirCraftApp.Infrastructure.Data;

/// <summary>
/// Implements the Unit of Work pattern for managing database operations.
/// Provides access to repositories and handles transaction management for changes in the database context.
/// </summary>
public class UnitOfWork(StirCraftDbContext context, ILogger<UnitOfWork> logger) : IUnitOfWork
{
    private readonly ConcurrentDictionary<string, object> _repositories = new();


    /// <summary>
    /// Retrieves or creates a repository for a specific entity type.
    /// Throws an exception if the repository type is not found.
    /// </summary>
    /// <typeparam name="T">The type of the entity for which the repository is required.</typeparam>
    /// <returns>An instance of <see cref="IRepository{T}"/> for the specified entity type.</returns>
    public IRepository<T> Repository<T>() where T : BaseEntity
    {
        var type = typeof(T).Name;

        return (IRepository<T>)_repositories.GetOrAdd(type, t =>
        {
            var repositoryType = typeof(Repository<>).MakeGenericType(typeof(T));
            logger.LogInformation($"Creating repository of type {repositoryType}");
            return Activator.CreateInstance(repositoryType, context)
                   ?? throw new InvalidOperationException($"Failed to create repository of type {t}");
        });
    }


    /// <summary>
    /// Saves all changes made to the database context within a transaction.
    /// Applies soft delete functionality for entities implementing <see cref="ISoftDeletable"/>.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result is <c>true</c> if changes were successfully saved, otherwise <c>false</c>.
    /// </returns>
    public async Task<bool> CompleteAsync()
    {
        await using var transaction = await context.Database.BeginTransactionAsync();

        try
        {
            foreach (var entry in context.ChangeTracker.Entries<ISoftDeletable>())
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Entity.IsDeleted = true;
                    logger.LogInformation($"Soft-deleting entity of type {entry.Entity.GetType().Name}");
                }
            }

            var changesSaved = await context.SaveChangesAsync() > 0;
            await transaction.CommitAsync();
            logger.LogInformation("Changes saved successfully");
            return changesSaved;
        }
        catch
        {
            await transaction.RollbackAsync();
            logger.LogError("An error occurred while saving changes. Rolling back changes.");
            throw;
        }
    }
}
