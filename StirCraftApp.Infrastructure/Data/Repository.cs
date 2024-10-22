﻿using Microsoft.EntityFrameworkCore;
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

    public async Task<TEntity?> GetEntityWithSpecAsync(ISpecification<TEntity> spec)
        => await ApplySpecification(spec)
            .FirstOrDefaultAsync();

    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await GetDbSet()
            .ToListAsync();

    public async Task<IReadOnlyList<TEntity>> GetAllAsReadOnlyAsync()
        => await GetDbSet()
            .AsNoTracking()
            .ToListAsync();

    public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity> spec)
        => await ApplySpecification(spec)
            .ToListAsync();

    public async Task<TResult?> GetEntityWithSpecAsync<TResult>(ISpecification<TEntity, TResult> spec)
     => await ApplySpecification(spec)
         .FirstOrDefaultAsync();

    public async Task<IEnumerable<TResult>> GetAllWithSpecAsync<TResult>(ISpecification<TEntity, TResult> spec)
        => await ApplySpecification(spec)
            .ToListAsync();

    public async Task AddAsync(TEntity entity)
        => await GetDbSet()
            .AddAsync(entity);

    public void Delete(TEntity entity)
        => GetDbSet()
            .Remove(entity);

    public void Update(TEntity entity)
    {
        GetDbSet().Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
    }

    private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
    {
        var query = GetDbSet()
            .AsQueryable();
        return SpecificationEvaluator<TEntity>.GetQuery(query, spec);
    }

    private IQueryable<TResult> ApplySpecification<TResult>(ISpecification<TEntity, TResult> spec)
    {
        var query = GetDbSet()
            .AsQueryable();
        return SpecificationEvaluator<TEntity>.GetQuery<TEntity, TResult>(query, spec);
    }
}
