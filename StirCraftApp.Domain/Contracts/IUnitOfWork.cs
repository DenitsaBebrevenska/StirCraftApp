using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.Contracts;
public interface IUnitOfWork
{
	//not going for IDisposable, the DI will take care
	IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
	Task CompleteAsync();

}
