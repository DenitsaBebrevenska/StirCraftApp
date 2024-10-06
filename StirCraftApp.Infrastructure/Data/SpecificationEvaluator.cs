using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Infrastructure.Data
{
	public class SpecificationEvaluator<T> where T : BaseEntity
	{
		public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
		{
			if (spec.Criteria != null)
			{
				query = query.Where(spec.Criteria);
			}

			return query;
		}
	}
}
