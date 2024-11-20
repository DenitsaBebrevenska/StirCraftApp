using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Infrastructure.Data;
public class Repository<T>(StirCraftDbContext context) : IRepository<T>
    where T : BaseEntity
{
    private DbSet<T> GetDbSet()
        => context.Set<T>();

    //public async Task<T?> GetByIdAsync(int id)
    //    => await GetDbSet()
    //        .FindAsync(id);

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

    //public async Task<IList<T>> GetAllAsync()
    //    => await GetDbSet()
    //        .ToListAsync();

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

    //public async Task<TResult?> GetEntityWithSpecAsync<TResult>(ISpecification<T, TResult> spec)
    // => await ApplySpecification(spec)
    //     .FirstOrDefaultAsync();

    //public async Task<IList<TResult>> GetAllAsync<TResult>(ISpecification<T, TResult> spec)
    //    => await ApplySpecification(spec)
    //        .ToListAsync();

    public async Task AddAsync(T entity)
        => await GetDbSet()
            .AddAsync(entity);

    public void Delete(T entity)
        => GetDbSet()
            .Remove(entity);

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


    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        var query = GetDbSet()
            .AsQueryable();
        return SpecificationEvaluator<T>.GetQuery(query, spec);
    }

    //private IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> spec)
    //{
    //    var query = GetDbSet()
    //        .AsQueryable()
    //        .AsNoTracking();
    //    return SpecificationEvaluator<T>.GetQuery<T, TResult>(query, spec);
    //}
}
