using StirCraftApp.Domain.Contracts;
using System.Linq.Expressions;

namespace StirCraftApp.Domain.Specifications;
public class BaseSpecification<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
{
	protected BaseSpecification() : this(null) { }
	public Expression<Func<T, bool>>? Criteria => criteria;
}
