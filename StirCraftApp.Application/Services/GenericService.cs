using StirCraftApp.Application.Contracts;
using StirCraftApp.Domain.Contracts;

namespace StirCraftApp.Application.Services;
public class GenericService<T>(IUnitOfWork unit) : IService<T> where T : class
{
    public async Task<T?> GetByIdAsync(int id)
        => await unit.Repository<T>()
            .GetByIdAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync()
        => await unit.Repository<T>()
            .GetAllAsync();

    public async Task<T?> GetWithSpecAsync(ISpecification<T> spec)
       => await unit.Repository<T>()
            .GetEntityWithSpecAsync(spec);


    public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        => await unit.Repository<T>()
            .GetAllWithSpecAsync(spec);

    public async Task<T> CreateAsync(T entity)
    {
        await unit.Repository<T>()
            .AddAsync(entity);

        await unit.CompleteAsync();

        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        unit.Repository<T>()
            .Update(entity);

        await unit.CompleteAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        unit.Repository<T>()
            .Delete(entity);
        await unit.CompleteAsync();
    }
}
