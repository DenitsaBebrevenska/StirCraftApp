using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Contracts;

namespace StirCraftApp.Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T : class
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
                query = query.OrderBy(spec.OrderByDesc);
            }

            if (spec.IsPaginationEnabled)
            {
                query = query.Skip(spec.Skip)
                    .Take(spec.Take);
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

        public static IQueryable<TResult> GetQuery<T, TResult>(IQueryable<T> query, ISpecification<T, TResult> spec)
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
                query = query.OrderBy(spec.OrderByDesc);
            }

            var selectQuery = query as IQueryable<TResult>;

            if (spec.Select != null)
            {
                selectQuery = query.Select(spec.Select);
            }

            if (spec.IsPaginationEnabled)
            {
                selectQuery = query.Skip(spec.Skip)
                    .Take(spec.Take) as IQueryable<TResult>;
            }

            return selectQuery ?? query.Cast<TResult>();
        }
    }
}
