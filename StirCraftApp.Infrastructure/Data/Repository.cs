using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Infrastructure.Data;

/// <summary>
/// A generic repository class that provides common data access methods for entities.
/// Implements basic CRUD operations and applies specifications for querying data from the database.
/// </summary>
/// <typeparam name="T">The type of entity this repository handles, which must inherit from <see cref="BaseEntity"/>.</typeparam>
public class Repository<T>(StirCraftDbContext context) : IRepository<T>
    where T : BaseEntity
{
    /// <summary>
    /// Retrieves the corresponding <see cref="DbSet{T}"/> for the entity type.
    /// </summary>
    /// <returns>A <see cref="DbSet{T}"/> for the specified entity type.</returns>
    private DbSet<T> GetDbSet()
        => context.Set<T>();

    /// <summary>
    /// Retrieves an entity by its ID with optional specification for filtering.
    /// </summary>
    /// <param name="spec">An optional specification to apply additional filters.</param>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <returns>The entity with the specified ID, or null if not found.</returns>
    public async Task<T?> GetByIdAsync(ISpecification<T>? spec, int id)
    {
        if (spec == null)
        {
            return await GetDbSet()
                .FindAsync(id); ;
        }

        return await ApplySpecification(spec)
            .FirstOrDefaultAsync(x => x.Id == id); ;
    }

    /// <summary>
    /// Retrieves all entities with an optional specification for filtering.
    /// </summary>
    /// <param name="spec">An optional specification to apply additional filters.</param>
    /// <returns>A list of entities matching the specification or all entities if no specification is provided.</returns>
    public async Task<IList<T>> GetAllAsync(ISpecification<T>? spec)
    {
        if (spec == null)
        {
            return await GetDbSet()
                .ToListAsync();
        }

        return await ApplySpecification(spec)
            .ToListAsync();
    }

    /// <summary>
    /// Adds a new entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    public async Task AddAsync(T entity)
        => await GetDbSet()
            .AddAsync(entity);

    /// <summary>
    /// Deletes an entity from the repository.
    /// If the entity implements <see cref="ISoftDeletable"/>, the entity is marked as deleted rather than physically removed.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    public void Delete(T entity)
    {
        if (entity is ISoftDeletable)
        {
            entity.DeletedOnUtc = DateTime.UtcNow;
            context.Entry(entity).State = EntityState.Deleted;
        }
        else
        {
            GetDbSet().Remove(entity);
        }
    }

    /// <summary>
    /// Attaches an entity to the change tracker and marks the state as modified.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    public void Update(T entity)
    {
        GetDbSet().Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
    }


    /// <summary>
    /// Checks if an entity with the specified ID exists in the repository.
    /// </summary>
    /// <param name="id">The ID of the entity to check for.</param>
    /// <returns>True if the entity exists, false otherwise.</returns>
    public async Task<bool> ExistsAsync(int id)
    {
        var entity = await GetDbSet()
            .FindAsync(id);

        return entity is not null;
    }

    /// <summary>
    /// Counts the number of entities that match an optional specification.
    /// </summary>
    /// <param name="spec">An optional specification to apply additional filters.</param>
    /// <returns>The count of entities matching the specification.</returns>
    public async Task<int> CountAsync(ISpecification<T>? spec)
    {
        var query = GetDbSet()
            .AsQueryable();

        if (spec != null)
        {
            query = spec.ApplyCriteria(query);
        }

        return await query
            .CountAsync();
    }

    /// <summary>
    /// Applies a specification to the repository query.
    /// </summary>
    /// <param name="spec">The specification to apply.</param>
    /// <returns>An <see cref="IQueryable{T}"/> with the specification applied.</returns>
    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        var query = GetDbSet()
            .AsQueryable();
        return SpecificationEvaluator<T>.GetQuery(query, spec);
    }

}
