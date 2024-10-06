using System.Linq.Expressions;

namespace StirCraftApp.Domain.Contracts;
public interface ISpecification<T>
{
	Expression<Func<T, bool>>? Criteria { get; }
}
