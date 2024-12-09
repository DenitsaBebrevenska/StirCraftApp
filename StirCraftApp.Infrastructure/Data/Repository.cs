using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Infrastructure.Data;
public class Repository<T>(StirCraftDbContext context) : IRepository<T>
    where T : BaseEntity
{
    private DbSet<T> GetDbSet()
        => context.Set<T>();

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

    public async Task AddAsync(T entity)
        => await GetDbSet()
            .AddAsync(entity);

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
    public void Update(T entity)
    {
        GetDbSet().Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        var entity = await GetDbSet()
            .FindAsync(id);

        return entity is not null;
    }

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


    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        var query = GetDbSet()
            .AsQueryable();
        return SpecificationEvaluator<T>.GetQuery(query, spec);
    }

}
