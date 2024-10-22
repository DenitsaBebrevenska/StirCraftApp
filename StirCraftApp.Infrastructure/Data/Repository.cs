using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Contracts;

namespace StirCraftApp.Infrastructure.Data;
public class Repository<T>(StirCraftDbContext context) : IRepository<T>
    where T : class
{
    private DbSet<T> GetDbSet()
        => context.Set<T>();

    public async Task<T?> GetByIdAsync(int id)
        => await GetDbSet()
            .FindAsync(id);

    public async Task<T?> GetEntityWithSpecAsync(ISpecification<T> spec)
        => await ApplySpecification(spec)
            .FirstOrDefaultAsync();

    public async Task<IEnumerable<T>> GetAllAsync()
        => await GetDbSet()
            .ToListAsync();

    public async Task<IReadOnlyList<T>> GetAllAsReadOnlyAsync()
        => await GetDbSet()
            .AsNoTracking()
            .ToListAsync();

    public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        => await ApplySpecification(spec)
            .ToListAsync();

    public async Task<TResult?> GetEntityWithSpecAsync<TResult>(ISpecification<T, TResult> spec)
     => await ApplySpecification(spec)
         .FirstOrDefaultAsync();

    public async Task<IEnumerable<TResult>> GetAllWithSpecAsync<TResult>(ISpecification<T, TResult> spec)
        => await ApplySpecification(spec)
            .ToListAsync();

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

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        var query = GetDbSet()
            .AsQueryable();
        return SpecificationEvaluator<T>.GetQuery(query, spec);
    }

    private IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> spec)
    {
        var query = GetDbSet()
            .AsQueryable();
        return SpecificationEvaluator<T>.GetQuery<T, TResult>(query, spec);
    }
}
