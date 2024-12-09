using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Contracts;

namespace StirCraftApp.Infrastructure.Data
{
    public static class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
        {
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDesc != null)
            {
                query = query.OrderByDescending(spec.OrderByDesc);
            }

            if (spec.IsPaginationEnabled)
            {
                query = query.Skip(spec.Skip)
                    .Take(spec.Take);
            }

            if (spec.SplitQueryEnabled)
            {
                query = query.AsSplitQuery();
            }

            //Eager loading
            query = spec.Includes
                .Aggregate(query, (current, include)
                    => current.Include(include));

            query = spec.IncludeStrings
                .Aggregate(query, (current, include)
                    => current.Include(include));

            return query;
        }

    }
}
