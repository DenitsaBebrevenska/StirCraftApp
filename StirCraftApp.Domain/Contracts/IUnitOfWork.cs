using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Contracts;
public interface IUnitOfWork
{
    //not going for IDisposable, the DI will take care
    IRepository<T> Repository<T>() where T : BaseEntity;
    Task<bool> CompleteAsync();

}
